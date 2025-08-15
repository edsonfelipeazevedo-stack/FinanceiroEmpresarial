using AutoMapper;
using FinanceiroEmpresarial.Domain.Entities;
using FinanceiroEmpresarial.Application.DTOs;

namespace FinanceiroEmpresarial.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Transacao, TransacaoDto>().ReverseMap();
        }
    }
}
