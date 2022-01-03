using BaseProject.Core.Domain.Models;
using BaseProject.Domain.Validations;

namespace BaseProject.Domain.Models
{
    public class Produto : BaseModel
    {
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }

        public override bool EhValido()
        {
            return new ProdutoValidation().Validate(this).IsValid;
        }
    }
}
