using Crossmatch.LSE;
using EOSDigital.API;
using SignalRHost.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        public async Task<string> Health()
        {
            return "ok";
        }

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
                return "success";
            }
            catch (Exception e)
            {
                Log.Error(e.Message + e.StackTrace);
                return "fail";
            }
            finally
            {
                DeleteZipFile(Constant.NKM_ZIP_PATH);
                DeleteZipFile(Constant.NK_ZIP_PATH);
            }
        }
        private void DeleteDirectory(string dirPath)
        {
            try
            {
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath,true);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error When Delete directory {ex.Message + ex.StackTrace}");
                throw;
            }
        }
        private void DeleteZipFile(string dirPath)
        {
            try
            {
                if (File.Exists(dirPath))
                {
                    File.Delete(dirPath);
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
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var byteArray = Encoding.ASCII.GetBytes($"{Constant.USER_NAME}:{Constant.PASSWORD}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                
                using var form = new MultipartFormDataContent();
                using var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(zipPath));
                var mediaType = new MediaTypeHeaderValue("multipart/form-data");
                
                fileContent.Headers.ContentType = mediaType;
                form.Add(fileContent, "file", Path.GetFileName(zipPath));
                var response = await client.PostAsync(url, form); 
                response.EnsureSuccessStatusCode();
                
                /*using (var multipartFormContent = new MultipartFormDataContent())
                {
                    //Load the file and set the file's Content-Type header
                    var fileStreamContent = new StreamContent(File.OpenRead(zipPath));
                    fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

                    //Add the file
                    multipartFormContent.Add(fileStreamContent, name: "file", fileName: Path.GetFileName(zipPath)+".zip");

                    //Send it
                    var response = await client.PostAsync(url, multipartFormContent);
                    response.EnsureSuccessStatusCode();
                }*/
                
                return true;
            }
            catch (Exception e)
            {
                Log.Error($"Error when send directory to server {e.Message + e.StackTrace}");
                throw;
            }
            
        }
        private bool CreateZipDir(string logsPath, string zipPath)
        {
            try
            {
                if (! Directory.Exists(logsPath)) return false;
                copyFiles(logsPath);
                DeleteZipFile(zipPath);
                ZipFile.CreateFromDirectory(Constant.TARGET_PATH, zipPath);
                DeleteDirectory(Constant.TARGET_PATH);
                return true;
            }
            catch (Exception e)
            {
                Log.Error($"Error when Create zip directory {e.Message + e.StackTrace}");
                throw;
            }
        }
        private void copyFiles(string sourcePath)
        {
            string fileName = "";
            string destFile = "";
            //string sourcePath = @"C:\NativeKit\NativeApp\logs";
            //string targetPath =  @"C:\NativeKit\logexport";

            // Use Path class to manipulate file and directory paths.
            /*string sourceFile = System.IO.Path.Combine(sourcePath);
             System.IO.Path.Combine(Constant.TARGET_PATH);*/

            // To copy a folder's contents to a new location:
            // Create a new target folder.
            // If the directory already exists, this method does not create a new directory.
            Directory.CreateDirectory(Constant.TARGET_PATH);

            /*
            // To copy a file to another location and
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
            */

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(Constant.TARGET_PATH, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }

            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }
    }
}
