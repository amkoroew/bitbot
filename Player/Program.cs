using System.Text.Json;
using Player.Logic;
using Player.Models;
using static Newtonsoft.Json.JsonConvert;

var app = WebApplication.Create(args);

app.MapPost("/", (JsonElement gameState) =>
    Strategy.Decide(DeserializeObject<GameState>(gameState.GetRawText()) ?? throw new InvalidOperationException()));

app.MapGet("/", () => "\ud83d\udcff.bitbotΔƛΩπ");

app.Run();