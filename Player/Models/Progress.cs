using Newtonsoft.Json;

namespace Player.Models;

public class Progress
{
    [JsonProperty("distance")]
    public uint Distance { get; set; }
        
    [JsonProperty("traveled")]
    public uint Traveled { get; set; }
}