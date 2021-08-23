namespace Lupincognito.Web.Shared.State;
public record ActionState(
    PlayerState Player,
    ActionType ActionType,
    short ActionNumber,
    CreatureColor TargetCreatureColor,
    Room TargetRoom
);
