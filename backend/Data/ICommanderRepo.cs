using System.Collections.Generic;
using AspnetcoreAPI.Models;

namespace AspnetcoreAPI.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}