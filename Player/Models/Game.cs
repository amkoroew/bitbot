using Newtonsoft.Json;

namespace Player.Models;

public class Game
{
    [JsonProperty("uid")]
    public uint Uid { get; set; }
        
    [JsonProperty("tick")]
    public uint Tick { get; set; }
        
    [JsonProperty("player_count")]
    public uint PlayerCount { get; set; }
        
    [JsonProperty("remaining_players")]
    public uint RemainingPlayers { get; set; }
        
    [JsonProperty("player")]
    public uint Player { get; set; }
}