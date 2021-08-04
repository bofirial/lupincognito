namespace Lupincognito.Web.Shared
{
    public record Player(
        string PlayerId,
        string DisplayName,
        PlayerStatus PlayerStatus,
        short TurnOrder,
        short HungerSkipsRemaining
    );
}
