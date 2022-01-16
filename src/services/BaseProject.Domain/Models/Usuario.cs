using BaseProject.Core.Domain.Models;
using BaseProject.Domain.Validations;

namespace BaseProject.Domain.Models
{
    public class Usuario : BaseModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new UsuarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
