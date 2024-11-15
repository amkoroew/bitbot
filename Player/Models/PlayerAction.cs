using Newtonsoft.Json;

namespace Player.Models;

public class PlayerAction
{
    [JsonProperty("src")]
    public uint Source { get; set; }

    [JsonProperty("dest")]
    public uint Destination { get; set; }

    [JsonProperty("amount")]
    public uint Amount { get; set; }
}