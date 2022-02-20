using Crossmatch.LSE;
using EOSDigital.API;
using SignalRHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Services
{
    public class Services : IServices
    {
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
                Serilog.Log.Error(ex.Message + ex.StackTrace);
            }
            return device;
        }
    }
}
