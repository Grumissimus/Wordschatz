using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordschatz.Application.CommandHandlers;
using Wordschatz.Application.Commands.Dictionaries;
using Wordschatz.Application.Interfaces;
using Wordschatz.Application.Queries.Dictionaries;
using Wordschatz.Application.QueryHandlers;
using Wordschatz.Application.ReadModels;
using Wordschatz.Domain.Models.Dictionaries;

namespace Wordschatz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public DictionaryReadModel Get([FromRoute]long id)
        {
            DictionaryReadModel res = null;

            try
            {
                Dictionary dict = _queryHandler.Execute(new DictionaryGetByIdQuery(id));
                res = DictionaryMapper.MapToReadModel(dict);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<DictionaryReadModel> GetMany([FromQuery]int pages = 1, [FromQuery]int amount = 20)
        {
            try
            {
                var dictionaries = _queryHandler.Execute(new DictionaryGetManyQuery(pages, amount));
                List <DictionaryReadModel> result = new List<DictionaryReadModel>();

                foreach( Dictionary d in dictionaries )
                {
                    result.Add( DictionaryMapper.MapToReadModel(d) );
                }

                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<DictionaryReadModel>();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateDictionaryCommand dictionary)
        {
            try
            {
                _commandHandler.Execute( dictionary );
                long dictionaryId = dictionary.DictionaryId;
                return RedirectToAction("Get", new { id = dictionaryId });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromRoute]long id, [FromBody] EditDictionaryCommand dictionary)
        {
            try
            {
                dictionary.DictionaryId = id;
                _commandHandler.Execute(dictionary);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]long id)
        {
            try
            {
                _commandHandler.Execute( new DeleteDictionaryCommand(id) );
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
