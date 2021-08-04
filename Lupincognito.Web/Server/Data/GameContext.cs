using Lupincognito.Web.Shared;
using Microsoft.EntityFrameworkCore;

namespace Lupincognito.Web.Server.Data
{
    public class GameContext : DbContext
    {
        public DbSet<GameState> GameStates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseInMemoryDatabase(databaseName: "Game");
    }
}
