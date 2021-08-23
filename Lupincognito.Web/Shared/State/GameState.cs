using System.Collections.Immutable;

namespace Lupincognito.Web.Shared.State;
public record GameState(
    string GameName,
    GameStatus GameStatus,
    string CurrentTurnPlayerId,
    DiceRollResult CurrentTurnDiceRoll,
    ImmutableList<PlayerState> Players,
    ImmutableList<CreatureState> Creatures,
    ImmutableList<ActionState> Actions
    );
