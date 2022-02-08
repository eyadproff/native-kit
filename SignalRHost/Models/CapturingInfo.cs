using Newtonsoft.Json;
using System;

namespace SignalRHost.Models
{
    [Serializable]
    public class CapturingInfo
    {
        [JsonProperty("deviceType")]
        public string DeviceType { get; set; }

        [JsonProperty("captureType")]
        public string CaptureType { get; set; }

        [JsonProperty("autoCapture")]
        public bool AutoCapture { get; set; }
    }
}
