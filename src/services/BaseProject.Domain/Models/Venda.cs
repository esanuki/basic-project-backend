using BaseProject.Core.Domain.Models;
using BaseProject.Domain.Validations;
using System;
using System.Collections.Generic;

namespace BaseProject.Domain.Models
{
    public class Venda : BaseModel
    {

        public Venda()
        {
            VendaItens = new HashSet<VendaItem>();
        }

        public DateTime DataVenda { get; set; }
        public decimal ValorTotal
        {
            get
            {
                decimal valor = 0;
                foreach (var item in VendaItens)
                {
                    valor += item.ValorTotal;
                }
                return valor;
            }
        }
        public decimal ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public IEnumerable<VendaItem> VendaItens { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new VendaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
