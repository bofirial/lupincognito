using System.Collections.Immutable;
using Fluxor;
using Lupincognito.Web.Shared;

namespace Lupincognito.Web.Client.State
{
    public class GameFeature : Feature<GameState>
    {
        public override string GetName() => nameof(GameState);
        protected override GameState GetInitialState() => new()
        {
            GameId = string.Empty,
            GameStatus = default,
            CurrentTurnPlayerId = string.Empty,
            CurrentTurnDiceRoll = default,
            Players = ImmutableList<Player>.Empty,
            Creatures = ImmutableList<Creature>.Empty,
            Actions = ImmutableList<Web.Shared.Action>.Empty
        };
    }
}
