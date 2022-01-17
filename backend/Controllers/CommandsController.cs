using System.Collections.Generic;
using AspnetcoreAPI.Data;
using AspnetcoreAPI.Dto;
using AspnetcoreAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspnetcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandDtoRead>> GetAll()
        {
            var commands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandDtoRead>>(commands));
        }

        [HttpGet("{id}")]
        public ActionResult<CommandDtoRead> Get(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command != null)
            {
                return Ok(_mapper.Map<CommandDtoRead>(command));
            }
            return NotFound();
        }

    }

}