using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordschatz.API.Buses;
using Wordschatz.Application.Dictionaries.Commands;
using Wordschatz.Application.Dictionaries.Mapper;
using Wordschatz.Application.Dictionaries.Queries;
using Wordschatz.Application.Dictionaries.ReadModels;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Dictionaries;

// Todo: Replace try/catch statements with the other way to message errors.
namespace Wordschatz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class DictionaryController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        public DictionaryController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute]long id)
        {
            try
            {
                Dictionary result = _queryBus.Send<DictionaryGetByIdQuery, Dictionary>( new DictionaryGetByIdQuery(id) );
                if (result == null) return NotFound(null);

                return Ok(DictionaryMapper.MapToReadModel(result));
            }
            catch (Exception e)
            {
                Console.Error.Write(e);
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMany([FromQuery]int amount = 20, [FromQuery]int pages = 1)
        {
            try
            {
                IEnumerable<Dictionary> dicts = _queryBus.Send<DictionaryGetManyQuery, List<Dictionary>>(new DictionaryGetManyQuery(amount, pages));
                var result = dicts.Select(x => DictionaryMapper.MapToReadModel(x)) ?? null;
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.Error.Write(e);
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateDictionaryCommand command)
        {
            try
            {
                _commandBus.Send(command);
                long dictionaryId = command.DictionaryId;
                return RedirectToAction("Get", new { id = dictionaryId });
            }
            catch (Exception e)
            {
                Console.Error.Write(e);
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromRoute]long id, [FromBody] EditDictionaryCommand command)
        {
            try
            {
                command.DictionaryId = id;
                _commandBus.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                Console.Error.Write(e);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]long id)
        {
            try
            {
                _commandBus.Send( new DeleteDictionaryCommand(id) );
                return Ok();
            }
            catch (Exception e)
            {
                Console.Error.Write(e);
                return BadRequest();
            }
        }
    }
}
