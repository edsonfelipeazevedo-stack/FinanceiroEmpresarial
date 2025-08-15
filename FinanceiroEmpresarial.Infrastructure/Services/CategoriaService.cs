using FinanceiroEmpresarial.Application.DTOs;
using FinanceiroEmpresarial.Application.Interfaces;
using FinanceiroEmpresarial.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceiroEmpresarial.Infrastructure.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly FinanceiroDbContext _context;

        public CategoriaService(FinanceiroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaDto>> GetCategoriasAsync()
        {
            var categorias = await _context.Categorias.Where(c => c.Ativo).ToListAsync();

            return categorias.Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Tipo = c.Tipo,
                Ativo = c.Ativo
            });
        }

        public async Task<CategoriaDto> CriarCategoriaAsync(CategoriaDto categoriaDto)
        {
            var categoria = new Domain.Entities.Categoria
            {
                Nome = categoriaDto.Nome,
                Tipo = categoriaDto.Tipo,
                Ativo = categoriaDto.Ativo
            };

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            categoriaDto.Id = categoria.Id;
            return categoriaDto;
        }
    }
}
