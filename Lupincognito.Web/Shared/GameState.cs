using System.Collections.Immutable;

namespace Lupincognito.Web.Shared
{
    public class GameState
    {
        public string GameId { get; init; }
        public GameStatus GameStatus { get; init; }
        public string CurrentTurnPlayerId { get; init; }
        public DiceRollResult CurrentTurnDiceRoll { get; init; }
        public ImmutableList<Player> Players { get; init; }
        public ImmutableList<Creature> Creatures { get; init; }
        public ImmutableList<Action> Actions { get; init; }
    }
}
