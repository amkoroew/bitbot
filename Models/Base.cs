using Newtonsoft.Json;

namespace PlayerDotNet.Models
{
    public class Base
    {
        [JsonProperty("position")]
        public required Position Position { get; set; }

        [JsonProperty("uid")]
        public uint Uid { get; set; }

        [JsonProperty("player")]
        public uint Player { get; set; }

        [JsonProperty("population")]
        public uint Population { get; set; }

        [JsonProperty("level")]
        public uint Level { get; set; }

        [JsonProperty("units_until_upgrade")]
        public uint UnitsUntilUpgrade { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }
    }
}
