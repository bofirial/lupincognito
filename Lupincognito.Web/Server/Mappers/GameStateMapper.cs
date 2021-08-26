using System.Collections.Immutable;
using Lupincognito.Web.Server.Data;
using Lupincognito.Web.Shared.State;

namespace Lupincognito.Web.Server.Mappers;
public interface IGameStateMapper
{
    GameState Map(Game game);
}

public class GameStateMapper : IGameStateMapper
{
    public GameState Map(Game game) => new(
        game.GameName,
        game.GameStatus,
        game.CurrentTurnPlayerId,
        game.CurrentTurnDiceRoll,
        game.Players.Select(p => Map(p)).ToImmutableList(),
        game.Creatures.Select(c => Map(c)).ToImmutableList(),
        game.Actions.Select(a => Map(a)).ToImmutableList()
        );

    private static PlayerState Map(Player player) => new(
                        player.DisplayName,
                        player.PlayerStatus,
                        player.TurnOrder,
                        player.HungerSkipsRemaining
                    );

    private static CreatureState Map(Creature creature) => new(
            creature.Color,
            creature.Room,
            creature.CreatureStatus
            );

    private static ActionState Map(Data.Action action) => new(
            Map(action.Player),
            action.ActionType,
            action.ActionNumber,
            action.TargetCreatureColor,
            action.TargetRoom
            );
}
