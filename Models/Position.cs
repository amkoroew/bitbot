﻿using Newtonsoft.Json;

namespace PlayerDotNet.Models
{
    public class Position
    {
        
        [JsonProperty("x")]
        public int X { get; set; }
        
        [JsonProperty("y")]
        public int Y { get; set; }
        
        [JsonProperty("z")]
        public int Z { get; set; }
    }
}