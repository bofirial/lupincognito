using System.Collections.Immutable;
using Fluxor;
using Lupincognito.Web.Shared.State;

namespace Lupincognito.Web.Client.State;
public class GameFeature : Feature<GameState>
{
    public override string GetName() => nameof(GameState);
    protected override GameState GetInitialState() => new(
        string.Empty,
        default,
        string.Empty,
        default,
        ImmutableList<PlayerState>.Empty,
        ImmutableList<CreatureState>.Empty,
        ImmutableList<ActionState>.Empty
        );
}
