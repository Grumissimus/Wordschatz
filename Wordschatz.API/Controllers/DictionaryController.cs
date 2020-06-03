using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Wordschatz.Application.Dictionaries.Commands;
using Wordschatz.Application.Dictionaries.Mapper;
using Wordschatz.Application.Dictionaries.Queries;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Dictionaries;

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
        public IActionResult Get([FromRoute] long id)
        {
            IResult<Dictionary> result = _queryBus.Send<DictionaryGetByIdQuery, Dictionary>(new DictionaryGetByIdQuery(id));

            if (!result.IsValid())
            {
                var Error = (InvalidResult<Dictionary>)result;
                return BadRequest(Error.Errors);
            }

            var Success = (SuccessResult<Dictionary>)result;
            Dictionary dictionary = Success.Data;

            return Ok(DictionaryMapper.MapToReadModel(dictionary));
        }

        [HttpGet]
        public IActionResult GetMany([FromQuery] int amount = 20, [FromQuery] int pages = 1)
        {
            IResult<List<Dictionary>> result = _queryBus.Send<DictionaryGetManyQuery, List<Dictionary>>(new DictionaryGetManyQuery(amount, pages));

            if (!result.IsValid())
            {
                var Error = (InvalidResult<List<Dictionary>>)result;
                return BadRequest(Error.Errors);
            }

            var Success = (SuccessResult<List<Dictionary>>)result;
            List<Dictionary> dictionaries = Success.Data;

            return Ok(dictionaries.Select(x => DictionaryMapper.MapToReadModel(x)));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDictionaryCommand command)
        {
            var result = _commandBus.Send(command);

            if (!result.IsValid())
            {
                var Error = (InvalidResult)result;
                return BadRequest(Error.Errors);
            }

            long dictionaryId = command.DictionaryId;
            return RedirectToAction("Get", new { id = dictionaryId });
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] long id, [FromBody] EditDictionaryCommand command)
        {
            command.DictionaryId = id;
            var result = _commandBus.Send(command);

            if (!result.IsValid())
            {
                var Error = (InvalidResult)result;
                return BadRequest(Error.Errors);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var result = _commandBus.Send(new DeleteDictionaryCommand(id));
            if (!result.IsValid())
            {
                var Error = (InvalidResult)result;
                return BadRequest(Error.Errors);
            }

            return Ok();
        }
    }
}