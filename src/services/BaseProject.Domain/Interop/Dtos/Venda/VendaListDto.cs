using System;

namespace BaseProject.Domain.Interop.Dtos.Venda
{
    public class VendaListDto
    {
        public decimal Id { get; set; }
        public DateTime DataVenda { get; set; }
        public string Cliente { get; set; }
        public decimal TotalVenda { get; set; }
    }
}
