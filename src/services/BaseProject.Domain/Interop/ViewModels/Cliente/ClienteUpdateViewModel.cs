using System;

namespace BaseProject.Domain.Interop.ViewModels.Cliente
{
    public class ClienteUpdateViewModel
    {
        public decimal Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
