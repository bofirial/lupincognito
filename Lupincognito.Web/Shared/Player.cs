namespace Lupincognito.Web.Shared
{
    public class Player
    {
        public string PlayerId { get; init; }
        public string DisplayName { get; init; }
        public PlayerStatus PlayerStatus { get; init; }
        public short TurnOrder { get; init; }
        public short HungerSkipsRemaining { get; init; }
    }
}
