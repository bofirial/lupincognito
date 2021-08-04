using System.Collections.Immutable;

namespace Lupincognito.Web.Shared
{
    public record GameState(
        string GameId,
        GameStatus GameStatus,
        string CurrentTurnPlayerId,
        DiceRollResult CurrentTurnDiceRoll,
        ImmutableList<Player> Players,
        ImmutableList<Creature> Creatures,
        ImmutableList<Action> Actions
    );
}
