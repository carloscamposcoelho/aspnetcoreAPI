using System.Collections.Generic;
using AspnetcoreAPI.Models;

namespace AspnetcoreAPI.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command>()
            {
                new Command { Id = 1, HowTo = "Cook", Line = "Grab all the itens", Platform = "Kitchen" },
                new Command { Id = 1, HowTo = "Take a shower", Line = "Take your cothes off", Platform = "Bathroom" },
                new Command { Id = 1, HowTo = "Tale a nap", Line = "Relax and close your eyes", Platform = "Bedroom" }
            };
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 1, HowTo = "Cook", Line = "Grab all the itens", Platform = "Kitchen" };
        }
    }
}