using System;

namespace BaseProject.Domain.Interop.ViewModels.Venda
{
    public class VendaItemViewModel
    {
        public decimal Id { get; set; }
        public int Qtde { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ProdutoId { get; set; }
    }
}
