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
        public async Task<ActionResult<IEnumerable<ReceitaDTO>>> GetReceitas()
        {
            var receitas = await _context.Receitas
               .Include(r => r.Proteina)
               .Include(r => r.Carboidrato)
               .Select(r => new ReceitaDTO
               {
                   Id = r.Id,
                   Nome = r.Nome,
                   TamanhoRecipiente = r.TamanhoRecipiente,
                   Proteina = r.Proteina.Nome,
                   Carboidrato = r.Carboidrato.Nome,
                   Verdura = r.Verdura,
                   DataCriacao = r.DataCriacao,
                   Favorita = r.Favorita
               })
               .ToListAsync();

            return Ok(receitas);
        }

        // GET: api/receitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceitaDTO>> GetReceita(Guid id)
        {
            var receita = await _context.Receitas
                .Include(r => r.Proteina)
                .Include(r => r.Carboidrato)
                .Where(r => r.Id == id)
                .Select(r => new ReceitaDTO
                {
                    Id = r.Id,
                    Nome = r.Nome,
                    TamanhoRecipiente = r.TamanhoRecipiente,
                    Proteina = r.Proteina.Nome,
                    Carboidrato = r.Carboidrato.Nome,
                    Verdura = r.Verdura,
                    DataCriacao = r.DataCriacao,
                    Favorita = r.Favorita
                })
                .FirstOrDefaultAsync();

            if (receita == null)
            {
                return NotFound();
            }

            return Ok(receita);
        }

        // PUT: api/receitas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(Guid id)
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
public async Task<ActionResult<ReceitaDTO>> CreateReceita([FromBody] ReceitaDTO receitaDto)
{
    // Carrega todos os ingredientes na memória
    var ingredientes = await _context.Ingredientes.ToListAsync();

    // Verifica ou cria a proteína
    var proteina = ingredientes
        .FirstOrDefault(i => i.Nome.Equals(receitaDto.Proteina, StringComparison.OrdinalIgnoreCase));

    if (proteina == null)
    {
        proteina = new Ingrediente
        {
            Id = Guid.NewGuid(),
            Nome = receitaDto.Proteina
        };
        _context.Ingredientes.Add(proteina);
        await _context.SaveChangesAsync();
    }

    // Verifica ou cria o carboidrato
    var carboidrato = ingredientes
        .FirstOrDefault(i => i.Nome.Equals(receitaDto.Carboidrato, StringComparison.OrdinalIgnoreCase));

    if (carboidrato == null)
    {
        carboidrato = new Ingrediente
        {
            Id = Guid.NewGuid(),
            Nome = receitaDto.Carboidrato
        };
        _context.Ingredientes.Add(carboidrato);
        await _context.SaveChangesAsync();
    }

    var receita = new Receitas
    {
        Id = Guid.NewGuid(),
        Nome = receitaDto.Nome,
        TamanhoRecipiente = receitaDto.TamanhoRecipiente,
        ProteinaId = proteina.Id,
        CarboidratoId = carboidrato.Id,
        Verdura = receitaDto.Verdura,
        DataCriacao = DateTime.UtcNow,
        Favorita = false
    };

    _context.Receitas.Add(receita);
    await _context.SaveChangesAsync();

    receitaDto.Id = receita.Id;
    receitaDto.DataCriacao = receita.DataCriacao;
    receitaDto.Proteina = proteina.Nome;
    receitaDto.Carboidrato = carboidrato.Nome;

    return CreatedAtAction(nameof(GetReceita), new { id = receita.Id }, receitaDto);
}

    }
}
