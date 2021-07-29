using Fluxor;

namespace Lupincognito.Web.Client.State
{
    public class GameFeature : Feature<GameState>
    {
        public override string GetName() => nameof(GameState);
        protected override GameState GetInitialState() => new();
    }
}
