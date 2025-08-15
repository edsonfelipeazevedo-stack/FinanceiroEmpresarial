using System;

namespace FinanceiroEmpresarial.Application.DTOs
{
    public class TransacaoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public string Observacoes { get; set; }
    }
}
