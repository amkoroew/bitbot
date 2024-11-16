using System.Text.Json;
using Player.Logic;
using Player.Models;
using static Newtonsoft.Json.JsonConvert;

var app = WebApplication.Create(args);

var logger = LoggerFactory.Create(config => { config.AddConsole(); }).CreateLogger("Program");

app.Urls.Add("http://*:3000");

app.MapPost("/", (JsonElement gameState) =>
{
    logger.LogInformation("=== thinking started ===");
    var actions = Strategy.Decide(DeserializeObject<GameState>(gameState.GetRawText()) ??
                                  throw new InvalidOperationException());
    logger.LogInformation(SerializeObject(actions));
    logger.LogInformation("=== thinking completed ===");
    return actions;
});

app.MapGet("/", () => "\ud83d\udcff.bitbotΔƛΩπ");

app.Run();