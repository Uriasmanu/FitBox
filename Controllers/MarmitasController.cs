using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitBox.Models;
using FitBox.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class MarmitasController : ControllerBase
{
    private readonly FitDbContext _context;

    public MarmitasController(FitDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Marmita>> CreateMarmita([FromBody] MarmitaCreateDto marmitaDto)
    {
        if (marmitaDto == null)
        {
            return BadRequest("Dados da marmita são necessários.");
        }

        // Verificar ou criar a proteína
        var proteina = await _context.Ingredientes
            .FirstOrDefaultAsync(i => i.Nome == marmitaDto.Proteina.Nome && i.Tipo == TipoIngrediente.Proteina);

        if (proteina == null)
        {
            proteina = new Ingrediente
            {
                Nome = marmitaDto.Proteina.Nome,
                Quantidade = marmitaDto.Proteina.Quantidade,
                Tipo = TipoIngrediente.Proteina
            };
            _context.Ingredientes.Add(proteina);
            await _context.SaveChangesAsync();
        }

        // Verificar ou criar o carboidrato
        var carboidrato = await _context.Ingredientes
            .FirstOrDefaultAsync(i => i.Nome == marmitaDto.Carboidrato.Nome && i.Tipo == TipoIngrediente.Carboidrato);

        if (carboidrato == null)
        {
            carboidrato = new Ingrediente
            {
                Nome = marmitaDto.Carboidrato.Nome,
                Quantidade = marmitaDto.Carboidrato.Quantidade,
                Tipo = TipoIngrediente.Carboidrato
            };
            _context.Ingredientes.Add(carboidrato);
            await _context.SaveChangesAsync();
        }

        // Criar a nova marmita
        var marmita = new Marmita
        {
            Nome = marmitaDto.Nome,
            TamanhoRecipiente = marmitaDto.TamanhoRecipiente,
            ProteinaId = proteina.Id,
            CarboidratoId = carboidrato.Id,
            Verdura = marmitaDto.Verdura,
            Favorita = false, // Valor padrão
            DataCriacao = DateTime.UtcNow,
        };

        _context.Marmitas.Add(marmita);
        await _context.SaveChangesAsync();

        // Verificar se a receita já existe na tabela Receitas
        var receitaExistente = await _context.Receitas
            .FirstOrDefaultAsync(r =>
                r.Nome == marmitaDto.Nome &&
                r.TamanhoRecipiente == marmitaDto.TamanhoRecipiente &&
                r.ProteinaId == proteina.Id &&
                r.CarboidratoId == carboidrato.Id &&
                r.Verdura == marmitaDto.Verdura);

        if (receitaExistente == null)
        {
            // Adicionar a nova receita à tabela Receitas
            var receita = new Receitas
            {
                Nome = marmitaDto.Nome,
                TamanhoRecipiente = marmitaDto.TamanhoRecipiente,
                ProteinaId = proteina.Id,
                CarboidratoId = carboidrato.Id,
                Verdura = marmitaDto.Verdura,
                DataCriacao = DateTime.UtcNow,
                Favorita = false, // Valor padrão
            };

            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();
        }

        return CreatedAtAction(nameof(GetMarmitaById), new { id = marmita.Id }, marmita);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Marmita>> GetMarmitaById(Guid id)
    {
        var marmita = await _context.Marmitas
            .Include(m => m.Proteina)
            .Include(m => m.Carboidrato)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (marmita == null)
        {
            return NotFound();
        }

        // Mapeia para DTO
        var marmitaDto = new
        {
            marmita.Id,
            marmita.Nome,
            marmita.TamanhoRecipiente,
            Proteina = new IngredienteDTO
            {
                Id = marmita.Proteina.Id,
                Nome = marmita.Proteina.Nome
            },
            Carboidrato = new IngredienteDTO
            {
                Id = marmita.Carboidrato.Id,
                Nome = marmita.Carboidrato.Nome
            },
            marmita.Verdura,
            marmita.Favorita,
            marmita.DataCriacao
        };

        return Ok(marmitaDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetAllMarmitas()
    {
        var marmitas = await _context.Marmitas
            .Include(m => m.Proteina)
            .Include(m => m.Carboidrato)
            .ToListAsync();

        var marmitaDtos = marmitas.Select(m => new
        {
            m.Id,
            m.Nome,
            m.TamanhoRecipiente,
            Proteina = new IngredienteDTO
            {
                Id = m.Proteina.Id,
                Nome = m.Proteina.Nome
            },
            Carboidrato = new IngredienteDTO
            {
                Id = m.Carboidrato.Id,
                Nome = m.Carboidrato.Nome
            },
            m.Verdura,
            m.Favorita,
            m.DataCriacao
        });

        return Ok(marmitaDtos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMarmita(Guid id)
    {
        var marmita = await _context.Marmitas.FindAsync(id);
        if (marmita == null)
        {
            return NotFound();
        }
        _context.Marmitas.Remove(marmita);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}