using System.Collections.Immutable;
using Lupincognito.Web.Server.Data;
using Lupincognito.Web.Shared;
using Microsoft.AspNetCore.SignalR;

namespace Lupincognito.Web.Server.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameContext _gameContext;

        public GameHub(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public async Task JoinGame(string gameName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameName);

            var gameState = _gameContext.GameStates.FirstOrDefault(x => x.GameId == gameName && x.GameStatus == GameStatus.Ready);

            if (gameState == null)
            {
                gameState = new GameState()
                {
                    GameId = gameName,
                    GameStatus = GameStatus.Ready,
                    CurrentTurnPlayerId = string.Empty,
                    CurrentTurnDiceRoll = default,
                    Players = ImmutableList.Create(new Player()
                    {
                        PlayerId = Context.ConnectionId,
                        DisplayName = "Player 1",
                        PlayerStatus = PlayerStatus.Spectating,
                        HungerSkipsRemaining = 3,
                        TurnOrder = default
                    }),
                    Creatures = ImmutableList<Creature>.Empty,
                    Actions = ImmutableList<Shared.Action>.Empty
                };

                _gameContext.GameStates.Add(gameState);

                await _gameContext.SaveChangesAsync();
            }

            //await Clients.Group(gameName).SendAsync("GameStateUpdate", new GameState());
        }
    }
}
