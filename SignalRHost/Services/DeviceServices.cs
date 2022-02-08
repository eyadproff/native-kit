using Crossmatch.LSE;
using EOSDigital.API;
using SignalRHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Services
{
    public class DeviceServices : IDeviceServices
    {
        CanonAPI canonApi;
        LseBioBaseApi biobApi = null;
        public async Task<List<DeviceDetails>> DevicesConnected()
        {
            try
            {
                List<DeviceDetails> deviceDetails = new();

                biobApi = new LseBioBaseApi();
                biobApi.Open();

                deviceDetails.Add(new DeviceDetails
                {
                    DeviceName = "Lscan",
                    CountOfDevices = biobApi.NumberOfDevices
                });

                canonApi = new CanonAPI();

                deviceDetails.Add(new DeviceDetails
                {
                    DeviceName = "Camera",
                    CountOfDevices = canonApi.GetCameraList().Count
                });

                return deviceDetails;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message + ex.StackTrace);
                throw;
            }
            
        }
    }
}
