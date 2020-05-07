using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordschatz.Application.CommandHandlers;
using Wordschatz.Application.Interfaces;
using Wordschatz.Application.Queries.Dictionaries;
using Wordschatz.Application.QueryHandlers;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly DictionaryQueryHandler _queryHandler;
        private readonly DictionaryCommandHandler _commandHandler;
        public DictionaryController(IQueryHandlerService queryHandler, ICommandHandlerService commandHandler)
        {
            _queryHandler = (DictionaryQueryHandler)queryHandler;
            _commandHandler = (DictionaryCommandHandler)commandHandler;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Dictionary Get(uint id)
        {
            Dictionary res = null;

            try
            {
                res = _queryHandler.Execute(new DictionaryGetByIdQuery(id));
            }
            catch( Exception e)
            {
                Console.WriteLine(e.Message);
                res = null;
            }

            return res;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Dictionary> GetMany([FromQuery]int pages, [FromQuery]int amount)
        {
            try
            {
                var result = _queryHandler.Execute(new DictionaryGetManyQuery(pages, amount));
                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Dictionary>();
            }
        }
    }
}
