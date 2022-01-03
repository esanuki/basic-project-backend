using BaseProject.Core.Domain.Models;
using BaseProject.Domain.Validations;
using System;

namespace BaseProject.Domain.Models
{
    public class Cliente : BaseModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public decimal EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public override bool EhValido()
        {
            return new ClienteValidation().Validate(this).IsValid;
        }
    }
}
