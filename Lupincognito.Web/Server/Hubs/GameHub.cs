using System.Threading.Tasks;
using Lupincognito.Web.Server.Data;
using Lupincognito.Web.Server.Mappers;
using Lupincognito.Web.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Lupincognito.Web.Server.Hubs;
public class GameHub : Hub
{
    private readonly GameContext _gameContext;
    private readonly IGameStateMapper _gameStateMapper;

    public GameHub(GameContext gameContext, IGameStateMapper gameStateMapper)
    {
        _gameContext = gameContext;
        _gameStateMapper = gameStateMapper;
    }

    public async Task JoinGame(string gameName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, gameName);

        var game = await _gameContext.Games
            .Include(x => x.Players)
            .Include(x => x.Creatures)
            .Include(x => x.Actions)
            .FirstOrDefaultAsync(x => x.GameName == gameName && x.GameStatus == GameStatus.Ready);

        if (game == null)
        {
            game = new()
            {
                GameName = gameName,
                GameStatus = GameStatus.Ready,
                CurrentTurnPlayerId = string.Empty,
                CurrentTurnDiceRoll = default,
                Players = new()
                {
                    new()
                    {
                        ConnectionId = Context.ConnectionId,
                        DisplayName = "Player 1",
                        PlayerStatus = PlayerStatus.Spectating,
                        HungerSkipsRemaining = 3,
                        TurnOrder = default
                    }
                },
                Creatures = new(),
                Actions = new()
            };

            _gameContext.Games.Add(game);

            await _gameContext.SaveChangesAsync();
        }
        else
        {
            game.Players.Add(new()
            {
                ConnectionId = Context.ConnectionId,
                DisplayName = $"Player {game.Players.Count + 1}",
                PlayerStatus = PlayerStatus.Spectating,
                HungerSkipsRemaining = 3,
                TurnOrder = default
            });

            await _gameContext.SaveChangesAsync();
        }

        await Clients.Group(gameName).SendAsync("GameStateUpdate", _gameStateMapper.Map(game));
    }
}
