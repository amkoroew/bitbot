using Newtonsoft.Json;

namespace PlayerDotNet.Models
{
    public class BaseLevel
    {
        
        [JsonProperty("max_population")]
        public uint MaxPopulation { get; set; }
        
        [JsonProperty("upgrade_cost")]
        public uint UpgradeCost { get; set; }
        
        [JsonProperty("spawn_rate")]
        public uint SpawnRate { get; set; }
    }
}
