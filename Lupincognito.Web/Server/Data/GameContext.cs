using Microsoft.EntityFrameworkCore;

namespace Lupincognito.Web.Server.Data;
public class GameContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Creature> Creatures { get; set; }
    public DbSet<Action> Actions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseInMemoryDatabase(databaseName: "GameDb");
}
