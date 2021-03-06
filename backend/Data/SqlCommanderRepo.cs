using System.Collections.Generic;
using System.Linq;
using AspnetcoreAPI.Models;

namespace AspnetcoreAPI.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void CreateCommand(Command cmd)
        {
            _context.Commands.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCommand(Command cmd)
        {
            //Do nothing. Don't forget to save changes!
        }

        public void DeleteCommand(Command cmd)
        {
            _context.Commands.Remove(cmd);
        }
    }

}