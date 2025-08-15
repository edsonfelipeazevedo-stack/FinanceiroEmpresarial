using FinanceiroEmpresarial.Application.DTOs;
using FinanceiroEmpresarial.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceiroEmpresarial.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        // GET api/relatorios/resumo?inicio=2025-01-01&fim=2025-01-31
        [HttpGet("resumo")]
        public async Task<ActionResult<ResumoFinanceiroDto>> GetResumo([FromQuery] DateTime inicio, [FromQuery] DateTime fim)
        {
            var resumo = await _relatorioService.ObterResumoAsync(inicio, fim);
            return Ok(resumo);
        }

        // GET api/relatorios/por-categoria?inicio=2025-01-01&fim=2025-01-31
        [HttpGet("por-categoria")]
        public async Task<ActionResult<IEnumerable<RelatorioPorCategoriaDto>>> GetPorCategoria([FromQuery] DateTime inicio, [FromQuery] DateTime fim)
        {
            var relatorio = await _relatorioService.ObterPorCategoriaAsync(inicio, fim);
            return Ok(relatorio);
        }
    }
}
