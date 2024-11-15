using System.Text.Json;
using Newtonsoft.Json;
using Player.Logic;
using Player.Models;

var app = WebApplication.Create(args);

app.Urls.Add("http://*:3000");

app.MapPost("/", (JsonElement gameState) => JsonConvert.SerializeObject(Strategy.Decide(JsonConvert.DeserializeObject<GameState>(gameState.GetRawText()))));

app.MapGet("/", () => "\ud83d\udcff.bitbotΔƛΩπ");

app.Run();