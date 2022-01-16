using BaseProject.Core.Domain.Models;
using BaseProject.Domain.Validations;

namespace BaseProject.Domain.Models
{
    public class VendaItem : BaseModel
    {
        public int Qtde { get; set; }
        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal
        {
            get { 
                return (Qtde * ValorUnitario) - Desconto; 
            }
            
        }

        public decimal Desconto { get; set; }
        public decimal VendaId { get; set; }
        public Venda Venda { get; set; }
        public decimal ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new VendaItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
