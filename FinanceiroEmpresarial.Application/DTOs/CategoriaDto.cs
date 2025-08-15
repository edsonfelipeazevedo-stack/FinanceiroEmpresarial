namespace FinanceiroEmpresarial.Application.DTOs
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }  // Receita ou Despesa
        public bool Ativo { get; set; }
    }
}
