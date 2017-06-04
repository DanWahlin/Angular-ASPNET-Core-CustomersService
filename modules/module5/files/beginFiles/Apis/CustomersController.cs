using Angular_ASPNETCore_CustomersService.Infrastructure;
using Angular_ASPNETCore_CustomersService.Models;
using Angular_ASPNETCore_CustomersService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angular_ASPNETCore_CustomersService.Apis
{
    [Route("api/customers")]
    public class CustomersApiController : Controller
    {
        ICustomersRepository _CustomersRepository;
        ILogger _Logger;

        public CustomersApiController(ICustomersRepository customersRepo, ILoggerFactory loggerFactory)
        {
            _CustomersRepository = customersRepo;
            _Logger = loggerFactory.CreateLogger(nameof(CustomersApiController));
        }

        [HttpGet] 
        [NoCache]
        [ProducesResponseType(typeof(List<Customer>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Customers()
        {
            try
            {
                var customers = await _CustomersRepository.GetCustomersAsync();
                return Ok(customers);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        [HttpGet("{id}", Name = "GetCustomerRoute")]
        [NoCache]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Customers(int id)
        {
            try
            {
                var customer = await _CustomersRepository.GetCustomerAsync(id);
                return Ok(customer);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

    }
}
