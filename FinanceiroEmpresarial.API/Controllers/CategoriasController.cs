using FinanceiroEmpresarial.Application.DTOs;
using FinanceiroEmpresarial.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceiroEmpresarial.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategorias()
        {
            var categorias = await _categoriaService.GetCategoriasAsync();
            return Ok(categorias);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> CriarCategoria([FromBody] CategoriaDto categoriaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novaCategoria = await _categoriaService.CriarCategoriaAsync(categoriaDto);
            return CreatedAtAction(nameof(GetCategorias), new { id = novaCategoria.Id }, novaCategoria);
        }
    }
}
