using FinanceiroEmpresarial.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceiroEmpresarial.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<ResumoFinanceiroDto> ObterResumoAsync(DateTime inicio, DateTime fim);
        Task<IEnumerable<RelatorioPorCategoriaDto>> ObterPorCategoriaAsync(DateTime inicio, DateTime fim);
    }
}
