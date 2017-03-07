using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angular_ASPNETCore_CustomersService.Models;
using Angular_ASPNETCore_CustomersService.Repository;
using Microsoft.Extensions.Logging;

namespace Angular_ASPNETCore_CustomersService.Controllers
{
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        IStatesRepository _StatesRepository;
        ILogger _Logger;

        public StatesController(IStatesRepository statesRepo, ILoggerFactory loggerFactory) {
            _StatesRepository = statesRepo;
            _Logger = loggerFactory.CreateLogger(nameof(StatesController));
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<State>), 200)]
        [ProducesResponseType(typeof(List<State>), 404)]
        public async Task<ActionResult> States() {
            try
            {
                var states = await _StatesRepository.GetStatesAsync();
                if (states == null)
                {
                    return NotFound();
                }
                return Ok(states);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest();
            }
        }

    }
}
