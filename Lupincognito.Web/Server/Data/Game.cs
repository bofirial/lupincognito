using Lupincognito.Web.Shared;

namespace Lupincognito.Web.Server.Data;
public class Game
{
    public int GameId { get; internal set; }
    public string GameName { get; internal set; }
    public GameStatus GameStatus { get; internal set; }
    public string CurrentTurnPlayerId { get; internal set; }
    public DiceRollResult CurrentTurnDiceRoll { get; internal set; }
    public List<Player> Players { get; internal set; }
    public List<Creature> Creatures { get; internal set; }
    public List<Action> Actions { get; internal set; }
}
