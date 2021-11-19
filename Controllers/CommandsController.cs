using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    // "api/commands"
    // [Route("api/[controller]")]
    [Route("api/commands")]
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
        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        // Get "api/commands"
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // Get "api/commands/{id}"
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }

        // Post "api/commands/"
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(commandModel);
            var saveChanges = _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            if (saveChanges)
            {
                return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
            }

            return BadRequest();
        }


        // Put "api/commands/{id}"
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commadModelFromRepo = _repository.GetCommandById(id);
            if (commadModelFromRepo == null)
            {
                return NotFound();
            }

            var mappedCommandUpdate = _mapper.Map(commandUpdateDto, commadModelFromRepo);

            _repository.UpdateCommand(mappedCommandUpdate);

            _repository.SaveChanges();

            return NoContent();
        }

        // Patch "api/commands/{id}"
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commadModelFromRepo = _repository.GetCommandById(id);
            if (commadModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commadModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            var mappedCommandUpdate = _mapper.Map(commandToPatch, commadModelFromRepo);


            _repository.UpdateCommand(mappedCommandUpdate);

            _repository.SaveChanges();

            return NoContent();
        }

        // Delete "api/commands/{id}"
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commadModelFromRepo = _repository.GetCommandById(id);
            if (commadModelFromRepo == null)
            {
                return NotFound();
            }


            _repository.DeleteCommand(commadModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }
    }
}