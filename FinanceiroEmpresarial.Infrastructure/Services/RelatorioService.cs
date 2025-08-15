using FinanceiroEmpresarial.Application.DTOs;
using FinanceiroEmpresarial.Application.Interfaces;
using FinanceiroEmpresarial.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceiroEmpresarial.Infrastructure.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly FinanceiroDbContext _context;

        public RelatorioService(FinanceiroDbContext context)
        {
            _context = context;
        }

        public async Task<ResumoFinanceiroDto> ObterResumoAsync(DateTime inicio, DateTime fim)
        {
            var transacoes = await _context.Transacoes
                .Include(t => t.Categoria)
                .Where(t => t.Data >= inicio && t.Data <= fim)
                .ToListAsync();

            var totalReceitas = transacoes
                .Where(t => t.Categoria.Tipo == "Receita")
                .Sum(t => t.Valor);

            var totalDespesas = transacoes
                .Where(t => t.Categoria.Tipo == "Despesa")
                .Sum(t => t.Valor);

            var saldoTotal = totalReceitas - totalDespesas;

            return new ResumoFinanceiroDto
            {
                SaldoTotal = saldoTotal,
                TotalReceitas = totalReceitas,
                TotalDespesas = totalDespesas
            };
        }

        public async Task<IEnumerable<RelatorioPorCategoriaDto>> ObterPorCategoriaAsync(DateTime inicio, DateTime fim)
        {
            var query = await _context.Transacoes
        .Include(t => t.Categoria) // inclui os dados da categoria relacionada
        .Where(t => t.Data >= inicio && t.Data <= fim)
        .GroupBy(t => new { t.CategoriaId, t.Categoria.Nome, t.Categoria.Tipo }) // agrupa por categoria
        .Select(g => new RelatorioPorCategoriaDto
        {
            CategoriaNome = g.Key.Nome,  // corresponde à propriedade do DTO
            Tipo = g.Key.Tipo,
            Total = g.Sum(t => t.Valor)  // soma dos valores no grupo
        })
        .ToListAsync();

            return query;
        }
    }
}
