using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Wordschatz.Application.Themes.Commands;
using Wordschatz.Application.Themes.Mappers;
using Wordschatz.Application.Themes.Queries;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;
using Wordschatz.Common.Results;
using Wordschatz.Domain.Models.Themes;

namespace Wordschatz.API.Controllers
{
    [ApiController]
    [Route("api/dictionary/{dictid}/theme")]
    public class ThemeController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public ThemeController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id, [FromRoute] long dictid)
        {
            IResult<Theme> result = _queryBus.Send<ThemeGetByIdQuery, Theme>(new ThemeGetByIdQuery(id, dictid));

            if (!result.IsValid())
            {
                var Error = (InvalidResult<Theme>)result;
                return BadRequest(Error.Errors);
            }

            var Success = (SuccessResult<Theme>)result;
            Theme theme = Success.Data;

            return Ok(ThemeMapper.MapToReadModel(theme));
        }

        [HttpGet]
        public IActionResult GetMany([FromRoute] long dictid, [FromQuery] int amount = 20, [FromQuery] int pages = 1)
        {
            IResult<List<Theme>> result = _queryBus.Send<ThemeGetManyQuery, List<Theme>>(new ThemeGetManyQuery(dictid, amount, pages));

            if (!result.IsValid())
            {
                var Error = (InvalidResult<List<Theme>>)result;
                return BadRequest(Error.Errors);
            }

            var Success = (SuccessResult<List<Theme>>)result;
            List<Theme> themes = Success.Data;

            return Ok(themes.Select(x => ThemeMapper.MapToReadModel(x)));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateThemeCommand command, [FromRoute] long dictid)
        {
            command.DictionaryId = dictid;
            var result = _commandBus.Send(command);

            if (!result.IsValid())
            {
                var Error = (InvalidResult<List<Theme>>)result;
                return BadRequest(Error.Errors);
            }

            long themeId = command.Id;
            return RedirectToAction("Get", new { id = themeId, dictid = dictid });
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] long id, [FromRoute] long dictid, [FromBody] EditThemeCommand command)
        {
            command.Id = id;
            command.DictionaryId = dictid;
            var result = _commandBus.Send(command);

            if (!result.IsValid())
            {
                var Error = (InvalidResult<List<Theme>>)result;
                return BadRequest(Error.Errors);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id, [FromRoute] long dictid)
        {
            var result = _commandBus.Send(new DeleteThemeCommand(id, dictid));
            if (!result.IsValid())
            {
                var Error = (InvalidResult<List<Theme>>)result;
                return BadRequest(Error.Errors);
            }

            return Ok();
        }
    }
}