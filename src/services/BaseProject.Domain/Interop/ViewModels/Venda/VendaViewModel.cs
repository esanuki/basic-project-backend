using System;
using System.Collections.Generic;

namespace BaseProject.Domain.Interop.ViewModels.Venda
{
    public class VendaViewModel
    {
        public decimal? Id { get; set; }
        public decimal ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public IEnumerable<VendaItemViewModel> VendaItens { get; set; }
    }
}
