using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Models
{
    [Serializable]
    public class Devices
    {
        public List<DeviceDetails> devices { get; set; }
    }
    
    [Serializable]
    public class DeviceDetails
    {
        public string DeviceName { get; set; }
        public int CountOfDevices { get; set; }
    }

    
}
