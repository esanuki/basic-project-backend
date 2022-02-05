using BaseProject.Domain.Interop.Dtos.Cliente;
using System;
using System.Collections.Generic;

namespace BaseProject.Domain.Interop.Dtos.Venda
{
    public class VendaDto
    {
        public decimal Id { get; set; }
        public DateTime DataVenda { get; set; }
        public ClienteDto Cliente { get; set; }
        public decimal ValorTotal { get; set; }
        public IEnumerable<VendaItemDto> VendaItens { get; set; }
    }
}
