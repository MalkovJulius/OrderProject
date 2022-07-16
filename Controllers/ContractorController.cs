using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.Services.ContractorService;
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
    public class ContractorController : Controller
    {
        private readonly IContractorService _service;
        public ContractorController(IContractorService service)
        {
            _service = service;
        }

        // GET api/<ContractorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractorDto>>> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllContractorsDtosAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // GET api/<ContractorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractorDto>> GetAsync(int id)
        {
            try
            {
                var instance = await _service.GetContractorDtoByIdAsync(id);
                if (instance == null) return NotFound();
                return Ok(instance);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<ContractorController>
        [HttpPost]
        public async Task<ActionResult> CreateAsync(ContractorDto contractorDto)
        {
            try
            {
                if (contractorDto == null) return BadRequest("Dto object is null");

                await _service.CreateContractorAsync(contractorDto);
                return CreatedAtAction(nameof(CreateAsync), null);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<ContractorController>/5
        [HttpPut]
        public async Task<ActionResult> EditAsync(ContractorDto contractorDto)
        {
            try
            {
                if (contractorDto == null) return BadRequest("Dto object is null");

                await _service.UpdateContractorAsync(contractorDto);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<ContractorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteContractorAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
