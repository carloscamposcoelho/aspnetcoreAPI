using AspnetcoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetcoreAPI.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; }

    }
}