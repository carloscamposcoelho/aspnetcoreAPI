using System.Collections.Generic;
using AspnetcoreAPI.Data;
using AspnetcoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspnetcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAll()
        {
            var commands = _repository.GetAllCommands();
            return Ok(commands);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> Get(int id)
        {
            var command = _repository.GetCommandById(id);
            return Ok(command);
        }

    }

}