using System;

namespace FinanceiroEmpresarial.Domain.Entities
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCriacao { get; set; }
        public Categoria Categoria { get; set; }  // Propriedade de navegação
    }
}
