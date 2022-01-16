using BaseProject.Core.Domain.Models;
using BaseProject.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Domain.Models
{
    public class Cliente : BaseModel
    {

        public Cliente()
        {
            Vendas = new HashSet<Venda>();
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public decimal EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        [NotMapped]
        public IEnumerable<Venda> Vendas { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new ClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
