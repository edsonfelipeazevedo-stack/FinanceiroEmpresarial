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
    public class TransacoesController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacoesController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoDto>>> GetTransacoes(
            [FromQuery] DateTime? inicio,
            [FromQuery] DateTime? fim,
            [FromQuery] int? categoriaId,
            [FromQuery] string tipo)
        {
            var transacoes = await _transacaoService.GetTransacoesAsync(inicio, fim, categoriaId, tipo);
            return Ok(transacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransacaoDto>> GetTransacao(int id)
        {
            var transacao = await _transacaoService.GetTransacaoByIdAsync(id);
            if (transacao == null)
                return NotFound();

            return Ok(transacao);
        }

        [HttpPost]
        public async Task<ActionResult<TransacaoDto>> CriarTransacao([FromBody] TransacaoDto transacaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novaTransacao = await _transacaoService.CriarTransacaoAsync(transacaoDto);
            return CreatedAtAction(nameof(GetTransacao), new { id = novaTransacao.Id }, novaTransacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTransacao(int id, [FromBody] TransacaoDto transacaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _transacaoService.AtualizarTransacaoAsync(id, transacaoDto);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTransacao(int id)
        {
            try
            {
                await _transacaoService.DeletarTransacaoAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }

            return NoContent();
        }
    }
}
