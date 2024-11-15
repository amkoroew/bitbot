using Newtonsoft.Json;

namespace PlayerDotNet.Models;

public class PathConfig
{
    [JsonProperty("grace_period")]
    public uint GracePeriod { get; set; }
        
    [JsonProperty("death_rate")]
    public uint DeathRate { get; set; }
}