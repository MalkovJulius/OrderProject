using Microsoft.AspNetCore.Mvc;
using OrderProject.Dtos;
using OrderProject.Services.OrderService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        // GET api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllOrdersAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetAsync(int id)
        {
            try
            {
                var instance = await _service.GetOrderDtoByIdAsync(id);
                if(instance == null) return NotFound();
                return Ok(instance);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> CreateAsync(OrderDto orderDto)
        {
            try
            {
                if(orderDto == null) return BadRequest("Dto object is null");

                await _service.CreateOrderAsync(orderDto);
                return CreatedAtAction(nameof(CreateAsync), null);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        public async Task<ActionResult> EditAsync(OrderDto orderDto)
        {
            try
            {
                if (orderDto == null) return BadRequest("Dto object is null");

                await _service.UpdateOrderAsync(orderDto);
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteOrderAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
