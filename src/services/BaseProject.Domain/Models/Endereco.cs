using BaseProject.Core.Domain.Models;
using BaseProject.Domain.Validations;
using FluentValidation.Results;

namespace BaseProject.Domain.Models
{
    public class Endereco : BaseModel
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public Cliente Cliente { get; set; }

        public override bool EhValido()
        {
            return new EnderecoValidation().Validate(this).IsValid;
        }
    }
}
