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
    public class TransacaoService : ITransacaoService
    {
        private readonly FinanceiroDbContext _context;

        public TransacaoService(FinanceiroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransacaoDto>> GetTransacoesAsync(DateTime? inicio, DateTime? fim, int? categoriaId, string tipo)
        {
            var query = _context.Transacoes.AsQueryable();

            if (inicio.HasValue)
                query = query.Where(t => t.Data >= inicio.Value);

            if (fim.HasValue)
                query = query.Where(t => t.Data <= fim.Value);

            if (categoriaId.HasValue)
                query = query.Where(t => t.CategoriaId == categoriaId.Value);

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(t => t.Categoria.Tipo == tipo);

            var transacoes = await query.Include(t => t.Categoria).ToListAsync();

            return transacoes.Select(t => new TransacaoDto
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Valor = t.Valor,
                Data = t.Data,
                CategoriaId = t.CategoriaId,
                Observacoes = t.Observacoes
            });
        }

        public async Task<TransacaoDto> GetTransacaoByIdAsync(int id)
        {
            var t = await _context.Transacoes.FindAsync(id);
            if (t == null) return null;

            return new TransacaoDto
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Valor = t.Valor,
                Data = t.Data,
                CategoriaId = t.CategoriaId,
                Observacoes = t.Observacoes
            };
        }

        public async Task<TransacaoDto> CriarTransacaoAsync(TransacaoDto transacaoDto)
        {
            var transacao = new Domain.Entities.Transacao
            {
                Descricao = transacaoDto.Descricao,
                Valor = transacaoDto.Valor,
                Data = transacaoDto.Data,
                CategoriaId = transacaoDto.CategoriaId,
                Observacoes = transacaoDto.Observacoes,
                DataCriacao = DateTime.UtcNow
            };

            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();

            transacaoDto.Id = transacao.Id;
            return transacaoDto;
        }

        public async Task AtualizarTransacaoAsync(int id, TransacaoDto transacaoDto)
        {
            var transacao = await _context.Transacoes.FindAsync(id);
            if (transacao == null) throw new Exception("Transação não encontrada");

            transacao.Descricao = transacaoDto.Descricao;
            transacao.Valor = transacaoDto.Valor;
            transacao.Data = transacaoDto.Data;
            transacao.CategoriaId = transacaoDto.CategoriaId;
            transacao.Observacoes = transacaoDto.Observacoes;

            await _context.SaveChangesAsync();
        }

        public async Task DeletarTransacaoAsync(int id)
        {
            var transacao = await _context.Transacoes.FindAsync(id);
            if (transacao == null) throw new Exception("Transação não encontrada");

            _context.Transacoes.Remove(transacao);
            await _context.SaveChangesAsync();
        }
    }
}
