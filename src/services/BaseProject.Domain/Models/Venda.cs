using BaseProject.Core.Domain.Models;
using BaseProject.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Domain.Models
{
    public class Venda : BaseModel
    {

        public Venda()
        {
            VendaItens = new HashSet<VendaItem>();
        }

        public DateTime DataVenda { get; set; }

        public decimal ValorTotal { get; set; }
        public decimal ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public IEnumerable<VendaItem> VendaItens { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new VendaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public void GetValorTotal()
        {
            decimal _valorTotal = 0;
            foreach (var item in VendaItens)
            {
                _valorTotal += item.ValorTotal;
            }

            ValorTotal = _valorTotal;
        }
    }
}
