using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Lupincognito.Web.Server.Hubs
{
    public class GameHub : Hub
    {
        public async Task JoinGameAsync(string gameName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameName);

            await Clients.Group(gameName).SendAsync("GameStateUpdate", $"{Context.User.Identity.Name} joined the game. ({Context.ConnectionId})");
        }
    }
}
