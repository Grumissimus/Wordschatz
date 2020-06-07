using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Marks;
using Wordschatz.Application.Marks.Queries;
using Wordschatz.Application.Marks.Commands;
using Wordschatz.Application.Dictionaries.Mapper;

namespace Wordschatz.API.Controllers
{
    [Route("api/dictionary/{dictid}/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public MarkController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long dictid, [FromRoute] long id)
        {
            IResult<Mark> result = _queryBus.Send<GetMarkByIdQuery, Mark>(new GetMarkByIdQuery(dictid, id));

            if (!result.IsValid())
            {
                var Error = (InvalidResult<Mark>)result;
                return BadRequest(Error.Errors);
            }

            var Success = (SuccessResult<Mark>)result;
            Mark dictionary = Success.Data;

            return Ok(MarkMapper.MapToReadModel(dictionary));
        }

        [HttpGet]
        public IActionResult GetMany([FromRoute] long dictid, [FromQuery] int amount = 20, [FromQuery] int pages = 1)
        {
            IResult<List<Mark>> result = _queryBus.Send<GetManyMarksQuery, List<Mark>>(new GetManyMarksQuery(dictid, amount, pages));

            if (!result.IsValid())
            {
                var Error = (InvalidResult<List<Mark>>)result;
                return BadRequest(Error.Errors);
            }

            var Success = (SuccessResult<List<Mark>>)result;
            List<Mark> dictionaries = Success.Data;

            return Ok(dictionaries.Select(x => MarkMapper.MapToReadModel(x)));
        }

        [HttpPost]
        public IActionResult Create([FromRoute] long dictid, [FromBody] CreateMarkCommand command)
        {
            command.DictionaryId = dictid;
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
        public IActionResult Put([FromRoute] long dictid, [FromRoute] long id, [FromBody] ChangeMarkCommand command)
        {
            command.DictionaryId = dictid;
            command.Id = id;
            var result = _commandBus.Send(command);

            if (!result.IsValid())
            {
                var Error = (InvalidResult)result;
                return BadRequest(Error.Errors);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long dictid, [FromRoute] long id)
        {
            var result = _commandBus.Send(new DeleteMarkCommand(dictid, id));
            if (!result.IsValid())
            {
                var Error = (InvalidResult)result;
                return BadRequest(Error.Errors);
            }

            return Ok();
        }
    }
}
