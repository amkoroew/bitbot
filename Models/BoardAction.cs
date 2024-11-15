using Newtonsoft.Json;

namespace PlayerDotNet.Models
{
    public class BoardAction
    {
        [JsonProperty("src")]
        public uint Src { get; set; }

        [JsonProperty("dest")]
        public uint Dest { get; set; }

        [JsonProperty("amount")]
        public uint Amount { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("player")]
        public uint Player { get; set; }

        [JsonProperty("progress")]
        public required Progress Progress { get; set; }
    }
}
