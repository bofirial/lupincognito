namespace Lupincognito.Web.Shared.State;
public record PlayerState(
    string ConnectionId,
    string DisplayName,
    PlayerStatus PlayerStatus,
    short TurnOrder,
    short HungerSkipsRemaining
);
