using System.Collections.Immutable;
using Fluxor;
using Lupincognito.Web.Shared;

namespace Lupincognito.Web.Client.State
{
    public class GameFeature : Feature<GameState>
    {
        public override string GetName() => nameof(GameState);
        protected override GameState GetInitialState() => new(
            string.Empty,
            default(GameStatus),
            string.Empty,
            default(DiceRollResult),
            ImmutableList<Player>.Empty,
            ImmutableList<Creature>.Empty,
            ImmutableList<Action>.Empty);
    }
}
