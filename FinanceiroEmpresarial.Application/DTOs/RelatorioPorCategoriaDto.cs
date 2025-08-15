namespace FinanceiroEmpresarial.Application.DTOs
{
    public class RelatorioPorCategoriaDto
    {
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
        public decimal Total { get; set; }
        public string Tipo { get; set; }  // Receita ou Despesa
    }
}
