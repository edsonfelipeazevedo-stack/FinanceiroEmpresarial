using FinanceiroEmpresarial.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceiroEmpresarial.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> GetCategoriasAsync();
        Task<CategoriaDto> CriarCategoriaAsync(CategoriaDto categoriaDto);
    }
}
