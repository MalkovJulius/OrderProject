using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProject.Dtos;
using OrderProject.Services.OutsourcingCompanyService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutsourcingCompanyController : Controller
    {
        private readonly IOutsourcingCompanyService _service;
        public OutsourcingCompanyController(IOutsourcingCompanyService service)
        {
            _service = service;
        }

        // GET api/<OutsourcingCompanyController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutsourcingCompanyDto>>> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllOutsourcingCompaniesAsync());
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<OutsourcingCompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutsourcingCompanyDto>> GetAsync(int id)
        {
            try
            {
                var instance = await _service.GetOutsourcingCompanyDtoByIdAsync(id);
                if (instance == null) return NotFound();
                return Ok(instance);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<OutsourcingCompanyController>
        [HttpPost]
        public async Task<ActionResult> CreateAsync(OutsourcingCompanyDto companyDto)
        {
            try
            {
                if (companyDto == null) return BadRequest("Dto object is null");

                await _service.CreateCompanyAsync(companyDto);
                return CreatedAtAction(nameof(CreateAsync), null);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<OutsourcingCompanyController>
        [HttpPut]
        public async Task<ActionResult> EditAsync(OutsourcingCompanyDto companyDto)
        {
            try
            {
                if (companyDto == null) return BadRequest("Dto object is null");

                await _service.UpdateCompanyAsync(companyDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<OutsourcingCompanyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteCompanyAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
