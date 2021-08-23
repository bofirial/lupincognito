using Lupincognito.Web.Shared;

namespace Lupincognito.Web.Server.Data;
public class Creature
{
    public int CreatureId { get; internal set; }
    public CreatureColor Color { get; internal set; }
    public Room Room { get; internal set; }
    public CreatureStatus CreatureStatus { get; internal set; }
}
