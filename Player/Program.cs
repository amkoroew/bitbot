using System.Text.Json;
using Newtonsoft.Json;
using Player.Logic;
using Player.Models;

var app = WebApplication.Create(args);

app.Urls.Add("http://*:3000");

app.MapPost("/", (JsonElement gameState) => Strategy.Decide(JsonConvert.DeserializeObject<GameState>(gameState.GetRawText()) ?? throw new InvalidOperationException()));

app.MapGet("/", () => "\ud83d\udcff.bitbotΔƛΩπ");

app.Run();