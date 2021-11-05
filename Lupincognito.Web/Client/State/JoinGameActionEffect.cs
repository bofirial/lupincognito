using System.Net;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace Lupincognito.Web.Client.State;
public class JoinGameActionEffect : Effect<JoinGameAction>
{
    private readonly NavigationManager _navigationManager;

    public JoinGameActionEffect(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public override Task HandleAsync(JoinGameAction action, IDispatcher dispatcher)
    {
        var urlEncodedGameName = WebUtility.UrlEncode(action.Name);

        _navigationManager.NavigateTo($"game/{urlEncodedGameName}");

        return Task.CompletedTask;
    }
}
