using Newtonsoft.Json;

namespace PlayerDotNet.Models
{
    public class Progress
    {
        [JsonProperty("distance")]
        public uint Distance { get; set; }
        
        [JsonProperty("traveled")]
        public uint Traveled { get; set; }
    }
}
