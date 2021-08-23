using System.Diagnostics.CodeAnalysis;
using Fluxor;
using Lupincognito.Web.Shared.State;

namespace Lupincognito.Web.Client.State;
public static class Reducers
{
    [ReducerMethod]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Parameter is requried by Fluxor")]
    public static GameState ReduceGameStateUpdateAction(GameState gameState, GameStateUpdateAction action) =>
        action.GameState;
}
