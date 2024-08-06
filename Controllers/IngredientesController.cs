using FitBox.DTOs;
using FitBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly FitDbContext _context;

        public IngredientesController(FitDbContext context)
        {
            _context = context;
        }

        // GET: api/ingredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredienteDTO>>> GetIngredientes()
        {
            var ingredientes = await _context.Ingredientes
                .Select(i => new IngredienteDTO
                {
                    Id = i.Id,
                    Nome = i.Nome,
                    Tipo = i.Tipo,
                    Favorita = i.Favorita 
                })
                .ToListAsync();

            return Ok(ingredientes);
        }

        // GET: api/ingredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredienteDTO>> GetIngrediente(Guid id)
        {
            var ingrediente = await _context.Ingredientes
                .Where(i => i.Id == id)
                .Select(i => new IngredienteDTO
                {
                    Id = i.Id,
                    Nome = i.Nome,
                    Tipo = i.Tipo,
                    Favorita = i.Favorita // Adicionando a propriedade Favorita no DTO
                })
                .FirstOrDefaultAsync();

            if (ingrediente == null)
            {
                return NotFound();
            }

            return Ok(ingrediente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngrediente(Guid id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            // Inverte o valor de Favorita
            ingrediente.Favorita = !ingrediente.Favorita;

            _context.Entry(ingrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(ingrediente);
        }



        // POST: api/ingredientes
        [HttpPost]
        public async Task<ActionResult<IngredienteDTO>> CreateIngrediente([FromBody] IngredienteDTO ingredienteDto)
        {
            var ingrediente = new Ingrediente
            {
                Id = Guid.NewGuid(),
                Nome = ingredienteDto.Nome,
                Tipo = ingredienteDto.Tipo,
                Favorita = ingredienteDto.Favorita
            };

            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIngrediente), new { id = ingrediente.Id }, ingredienteDto);
        }


        private bool IngredienteExists(Guid id)
        {
            return _context.Ingredientes.Any(e => e.Id == id);
        }
    }
}
