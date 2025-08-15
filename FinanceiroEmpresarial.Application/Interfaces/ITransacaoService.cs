using FinanceiroEmpresarial.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceiroEmpresarial.Application.Interfaces
{
    public interface ITransacaoService
    {
        Task<IEnumerable<TransacaoDto>> GetTransacoesAsync(DateTime? inicio, DateTime? fim, int? categoriaId, string tipo);
        Task<TransacaoDto> GetTransacaoByIdAsync(int id);
        Task<TransacaoDto> CriarTransacaoAsync(TransacaoDto transacaoDto);
        Task AtualizarTransacaoAsync(int id, TransacaoDto transacaoDto);
        Task DeletarTransacaoAsync(int id);
    }
}
