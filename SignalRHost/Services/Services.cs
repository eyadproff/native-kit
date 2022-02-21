using Crossmatch.LSE;
using EOSDigital.API;
using SignalRHost.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Serilog;
using SignalRHost.Utilities;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace SignalRHost.Services
{
    public class Services : IServices
    {
        static readonly HttpClientHandler httpClientHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true
        };
        private static readonly HttpClient client = new HttpClient(httpClientHandler);
        public async Task<Devices> DevicesConnected()
        {
            Devices devices = new();
            List<DeviceDetails> deviceDetails = new();
            try
            {
                deviceDetails.Add(await Canon());
                deviceDetails.Add(await Lscan());
                devices.devices = deviceDetails;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message + ex.StackTrace);
                deviceDetails.Clear();
                deviceDetails.Add(new DeviceDetails
                {
                    DeviceName = "",
                    CountOfDevices = 0
                });
            }

            return devices;
        }

        private async Task<DeviceDetails> Canon()
        {
            CanonAPI canonApi;
            var device = new DeviceDetails();
            device.DeviceName = "Canon";
            device.CountOfDevices = 0;
            try
            {
                canonApi = new CanonAPI();
                device.CountOfDevices = canonApi.GetCameraList().Count;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message + ex.StackTrace);
            }
            return device;
        }
        private async Task<DeviceDetails> Lscan()
        {
            var device = new DeviceDetails();
            LseBioBaseApi biobApi = null;

            device.DeviceName = "Lscan";
            device.CountOfDevices = 0;
            try
            {
                biobApi = new LseBioBaseApi();
                biobApi.Open();
                device.CountOfDevices = biobApi.NumberOfDevices;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + ex.StackTrace);
            }
            return device;
        }

        public async Task<string> SendLogs()
        {
            try
            {
                if (!CreateZipDir(Constant.NK_LOGS_PATH, Constant.NK_ZIP_PATH)) return "fail";
                if (!CreateZipDir(Constant.NKM_LOGS_PATH, Constant.NKM_ZIP_PATH)) return "fail";
                if (!SendToServer(Constant.SERVER_URL, Constant.NK_ZIP_PATH).Result) return "fail";
                if (!SendToServer(Constant.SERVER_URL, Constant.NKM_ZIP_PATH).Result) return "fail";
                Log.Information("Send log directory to server successful");
                return "successful";
            }
            catch (Exception e)
            {
                Log.Error(e.Message + e.StackTrace);
                return "fail";
            }
            finally
            {
                DeleteZipDir(Constant.NKM_ZIP_PATH);
                DeleteZipDir(Constant.NK_ZIP_PATH);
            }
        }

        private void DeleteZipDir(string dirPath)
        {
            try
            {
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error When Delete directory {ex.Message + ex.StackTrace}");
                throw;
            }
        }
        private async Task<bool> SendToServer(string url, string zipPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(zipPath) )
                {
                    throw new ArgumentNullException(nameof(zipPath));
                }
                if (!File.Exists(zipPath))
                {
                    throw new FileNotFoundException($"File [{zipPath}]not found.");
                }
                using var form = new MultipartFormDataContent();
                using var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(zipPath));
                var mediaType = new MediaTypeHeaderValue("multipart/form-data");
                fileContent.Headers.ContentType = mediaType;
                form.Add(fileContent, "file", Path.GetFileName(zipPath));
                var response = await client.PostAsync(url, form);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception e)
            {
                Log.Error($"Error when send directory to server {e.Message + e.StackTrace}");
                return false;
            }
            
        }
        private bool CreateZipDir(string logsPath, string zipPath)
        {
            try
            {
                if (! Directory.Exists(logsPath)) return false;
                ZipFile.CreateFromDirectory(logsPath, zipPath);
                return true;
            }
            catch (Exception e)
            {
                Log.Error($"Error when Create zip directory {e.Message + e.StackTrace}");
                return false;
            }
            
        }
            
    }
}
