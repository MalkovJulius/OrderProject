using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.Dtos;
using OrderProject.Services.CustomerService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        // GET api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllCustomersAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetAsync(int id)
        {
            try
            {
                var instance = await _service.GetCustomerDtoByIdAsync(id);
                if (instance == null) return NotFound();
                return Ok(instance);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult> CreateAsync(CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null) return BadRequest("Dto object is null");

                await _service.CreateCustomerAsync(customerDto);
                return CreatedAtAction(nameof(CreateAsync), null);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public async Task<ActionResult> EditAsync(CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null) return BadRequest("Dto object is null");

                await _service.UpdateCustomerAsync(customerDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteCustomerAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
