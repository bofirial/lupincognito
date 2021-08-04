using System.Threading.Tasks;
using Lupincognito.Web.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace Lupincognito.Web.Client.Messenger
{
    public interface IGameHubMessenger
    {
        Task StartConnectionAsync(string gameName);
    }

    public class GameHubMessenger : IGameHubMessenger
    {
        private const string HubUri = "/gamehub";
        private HubConnection _hubConnection;
        private readonly NavigationManager _navigationManager;
        private readonly ILogger<GameHubMessenger> _logger;

        public GameHubMessenger(NavigationManager navigationManager, ILogger<GameHubMessenger> logger)
        {
            _navigationManager = navigationManager;
            _logger = logger;
        }

        public async Task StartConnectionAsync(string gameName)
        {
            _hubConnection = new HubConnectionBuilder()
            .WithUrl(_navigationManager.ToAbsoluteUri(HubUri))
            .Build();

            _hubConnection.On<GameState>("GameStateUpdate", (message) =>
            {

            });

            await _hubConnection.StartAsync();

            await _hubConnection.SendAsync("JoinGame", gameName);
        }
    }
}
