using Lupincognito.Web.Shared;

namespace Lupincognito.Web.Server.Data;
public class Player
{
    public int PlayerId { get; internal set; }
    public string ConnectionId { get; internal set; }
    public string DisplayName { get; internal set; }
    public PlayerStatus PlayerStatus { get; internal set; }
    public short TurnOrder { get; internal set; }
    public short HungerSkipsRemaining { get; internal set; }
}
