using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Models
{
    [Serializable]
    public class DeviceDetails
    {
        [JsonProperty("device")]
        public string DeviceName { get; set; }
        [JsonProperty("countOfDevices")]
        public int CountOfDevices { get; set; }
    }
}
