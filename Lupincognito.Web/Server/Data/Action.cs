using Lupincognito.Web.Shared;

namespace Lupincognito.Web.Server.Data;
public class Action
{
    public int ActionId { get; internal set; }
    public int PlayerId { get; internal set; }
    public Player Player { get; internal set; }
    public ActionType ActionType { get; internal set; }
    public short ActionNumber { get; internal set; }
    public CreatureColor TargetCreatureColor { get; internal set; }
    public Room TargetRoom { get; internal set; }
}
