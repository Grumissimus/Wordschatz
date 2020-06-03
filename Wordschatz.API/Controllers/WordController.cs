using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Wordschatz.Application.Words.Mappers;
using Wordschatz.Application.Words.Queries;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Words;

namespace Wordschatz.API.Controllers
{
    [ApiController]
    [Route("api/dictionary/{dictid}/theme/{themeid}/[controller]")]
    public class WordController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public WordController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long dictid, [FromRoute] long themeid, [FromRoute] long id)
        {
            IResult<Word> result = _queryBus.Send<GetWordByIdQuery, Word>(new GetWordByIdQuery(dictid, themeid, id));

            if (!result.IsValid())
            {
                var Error = (InvalidResult<Word>)result;
                return BadRequest(Error.Errors);
            }

            var Success = (SuccessResult<Word>)result;
            Word word = Success.Data;

            return Ok(WordMapper.MapToReadModel(word));
        }

        [HttpGet]
        public IActionResult GetMany([FromRoute] long dictid, [FromRoute] long themeid, [FromQuery] int amount = 20, [FromQuery] int pages = 1)
        {
            IResult<List<Word>> result = _queryBus.Send<GetManyWordsQuery, List<Word>>(new GetManyWordsQuery(dictid, themeid, amount, pages));

            if (!result.IsValid())
            {
                var Error = (InvalidResult<List<Word>>)result;
                return BadRequest(Error.Errors);
            }

            var Success = (SuccessResult<List<Word>>)result;
            List<Word> themes = Success.Data;

            return Ok(themes.Select(x => WordMapper.MapToReadModel(x)));
        }
    }
}