using Microsoft.AspNetCore.Mvc;
using MinhaApp.Application.Interfaces;
using MinhaApp.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExemploController : ControllerBase
    {
        private readonly IExemploService _exemploService;

        public ExemploController(IExemploService exemploService)
        {
            _exemploService = exemploService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExemploDto>>> GetAll()
        {
            var exemplos = await _exemploService.GetAllAsync();
            return Ok(exemplos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExemploDto>> GetById(int id)
        {
            var exemplo = await _exemploService.GetByIdAsync(id);
            if (exemplo == null)
            {
                return NotFound();
            }
            return Ok(exemplo);
        }

        [HttpPost]
        public async Task<ActionResult<ExemploDto>> Create([FromBody] ExemploDto exemploDto)
        {
            var createdExemplo = await _exemploService.CreateAsync(exemploDto);
            return CreatedAtAction(nameof(GetById), new { id = createdExemplo.Id }, createdExemplo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ExemploDto exemploDto)
        {
            if (id != exemploDto.Id)
            {
                return BadRequest();
            }

            await _exemploService.UpdateAsync(exemploDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _exemploService.DeleteAsync(id);
            return NoContent();
        }
    }
}