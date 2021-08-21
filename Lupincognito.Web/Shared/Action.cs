namespace Lupincognito.Web.Shared
{
    public class Action
    {
        public string PlayerId { get; init; }
        public ActionType ActionType { get; init; }
        public short ActionNumber { get; init; }
        public CreatureColor TargetCreatureColor { get; init; }
        public Room TargetRoom { get; init; }
    }
}
