using BaseProject.Core.Domain.Models;
using BaseProject.Domain.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Domain.Models
{
    public class Produto : BaseModel
    {
        public Produto()
        {
            VendaItens = new HashSet<VendaItem>();
        }

        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }

        [NotMapped]
        public IEnumerable<VendaItem> VendaItens { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new ProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
