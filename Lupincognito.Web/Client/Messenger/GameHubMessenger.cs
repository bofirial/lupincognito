using System.Threading.Tasks;
using Fluxor;
using Lupincognito.Web.Client.State;
using Lupincognito.Web.Shared.State;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Lupincognito.Web.Client.Messenger;
public interface IGameHubMessenger
{
    Task StartConnectionAsync(string gameName);
}

public class GameHubMessenger : IGameHubMessenger
{
    private const string HubUri = "/gamehub";
    private HubConnection _hubConnection;
    private readonly NavigationManager _navigationManager;
    private readonly IDispatcher _dispatcher;

    public GameHubMessenger(NavigationManager navigationManager, IDispatcher dispatcher)
    {
        _navigationManager = navigationManager;
        _dispatcher = dispatcher;
    }

    public async Task StartConnectionAsync(string gameName)
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(_navigationManager.ToAbsoluteUri(HubUri))
            .Build();

        _hubConnection.On<GameState>("GameStateUpdate", (gameState) => _dispatcher.Dispatch(new GameStateUpdateAction(gameState)));

        await _hubConnection.StartAsync();

        await _hubConnection.SendAsync("JoinGame", gameName);
    }
}
