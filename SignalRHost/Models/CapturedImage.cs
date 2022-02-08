using Newtonsoft.Json;
using System;

namespace SignalRHost.Models
{
    [Serializable]
    public class CapturedImage
    {
        [JsonProperty("device")]
        public string DeviceName { get; set; }

        [JsonProperty("image")]
        public string Base64String { get; set; }
    }
}
