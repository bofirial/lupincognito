namespace Lupincognito.Web.Shared
{
    public record Action(
        string PlayerId,
        ActionType ActionType,
        short ActionNumber,
        CreatureColor TargetCreatureColor,
        Room TargetRoom
    );
}
