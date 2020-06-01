using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordschatz.Application.Themes.Commands;
using Wordschatz.Application.Themes.Mappers;
using Wordschatz.Application.Themes.Queries;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute] long id, [FromRoute] long dictid)
        {
            try
            {
                Theme result = _queryBus.Send<ThemeGetByIdQuery, Theme>(new ThemeGetByIdQuery(id, dictid));
                if (result == null) return NotFound(result);

                return Ok(ThemeMapper.MapToReadModel(result));
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
        public IActionResult GetMany([FromRoute] long dictid, [FromQuery] int amount = 20, [FromQuery] int pages = 1)
        {
            try
            {
                IEnumerable<Theme> dicts = _queryBus.Send<ThemeGetManyQuery, List<Theme>>(new ThemeGetManyQuery(dictid, amount, pages));
                var result = dicts.Select(x => ThemeMapper.MapToReadModel(x)) ?? null;
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
        public IActionResult Create([FromBody] CreateThemeCommand command, [FromRoute] long dictid)
        {
            try
            {
                command.DictionaryId = dictid;
                _commandBus.Send(command);
                long themeId = command.Id;
                return RedirectToAction("Get", new { id = themeId, dictid = dictid });
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
        public IActionResult Put([FromRoute] long id, [FromRoute] long dictid, [FromBody] EditThemeCommand command)
        {
            try
            {
                command.Id = id;
                command.DictionaryId = dictid;
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
        public IActionResult Delete([FromRoute] long id, [FromRoute] long dictid)
        {
            try
            {
                _commandBus.Send(new DeleteThemeCommand(id, dictid));
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
