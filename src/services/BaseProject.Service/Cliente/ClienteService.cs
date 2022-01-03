using AutoMapper;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Core.Service;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Cliente;
using System.Threading.Tasks;

namespace BaseProject.Service.Cliente
{
    public class ClienteService : Service<Domain.Models.Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(
            IClienteRepository repository, 
            IMapper mapper, 
            INotificador notificador) : base(repository, mapper, notificador)
        {
            _clienteRepository = repository;
        }

        public async Task<ClienteDto> SelecionarComEndereco(decimal id)
        {
            var result = await _clienteRepository.SelecionarComEndereco(id);
            return _mapper.Map<ClienteDto>(result);
        }
    }
}
