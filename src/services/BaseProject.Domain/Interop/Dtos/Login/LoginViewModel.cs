using System.ComponentModel.DataAnnotations;

namespace BaseProject.Domain.Interop.Dtos.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail é campo obrigatório para Login")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(60, ErrorMessage = "E-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é campo obrigatório para Login")]
        [StringLength(60, ErrorMessage = "E-mail deve ter no máximo {1} caracteres.")]
        public string Senha { get; set; }
    }
}
