using BaseProject.Domain.Interop.Dtos.Produto;

namespace BaseProject.Domain.Interop.Dtos.Venda
{
    public class VendaItemDto
    {
        public decimal Id { get; set; }
        public int Qtde { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public ProdutoDto Produto { get; set; }
    }
}
