using System;

namespace BaseProject.Domain.Interop.Dtos.Cliente
{
    public class ClienteDto
    {
        public decimal Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
