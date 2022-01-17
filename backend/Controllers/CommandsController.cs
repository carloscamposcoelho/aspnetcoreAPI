using System;
using System.Collections.Generic;
using AspnetcoreAPI.Data;
using AspnetcoreAPI.Dto;
using AspnetcoreAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAll()
        {
            var commands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<CommandReadDto> Get(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> Create(CommandCreateDto commandDtoCreate)
        {
            if (commandDtoCreate == null)
            {
                throw new ArgumentNullException(nameof(commandDtoCreate));
            }

            var commandModel = _mapper.Map<Command>(commandDtoCreate);

            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandDtoRead = _mapper.Map<CommandReadDto>(commandModel);

            //returns a 201 HttpStatusCode with the header Location containing the url to the resource created
            return CreatedAtRoute(nameof(Get), new { id = commandDtoRead.Id }, commandDtoRead);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, CommandUpdateDto commandDtoUpdate)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandDtoUpdate, commandFromRepo);

            _repository.UpdateCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdatePatch(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandFromRepo);

            _repository.UpdateCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}