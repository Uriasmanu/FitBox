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
    public class ReceitasController : ControllerBase
    {
        private readonly FitDbContext _context;

        public ReceitasController(FitDbContext context)
        {
            _context = context;
        }

        // GET: api/receitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receitas>>> GetReceitas()
        {
            return await _context.Receitas.ToListAsync();
        }

        // GET: api/receitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receitas>> GetReceita(Guid id)
        {
            var receita = await _context.Receitas.FindAsync(id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        // PUT: api/receitas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceitas(Guid id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            // Inverte o valor de Favorita
            receita.Favorita = !receita.Favorita;

            _context.Entry(receita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(receita);
        }


        // POST: api/receitas
        [HttpPost]
        public async Task<ActionResult<Receitas>> PostReceita(Receitas receita)
        {
            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReceita), new { id = receita.Id }, receita);
        }

        // DELETE: api/receitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceita(Guid id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceitaExists(Guid id)
        {
            return _context.Receitas.Any(e => e.Id == id);
        }
    }
}
