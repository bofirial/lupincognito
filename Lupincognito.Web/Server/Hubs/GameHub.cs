using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Lupincognito.Web.Server.Hubs
{
    public class GameHub : Hub
    {
        public GameHub()
        {

        }

        public async Task JoinGame(string gameName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameName);

            //await Clients.Group(gameName).SendAsync("GameStateUpdate", new GameState());
        }
    }
}
