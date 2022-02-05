using AutoMapper;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Core.Service;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Venda;
using BaseProject.Domain.Interop.ViewModels.Venda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseProject.Service.Venda
{
    public class VendaService : Service<Domain.Models.Venda>, IVendaService
    {
        private IVendaRepository _vendaRepository;
        public VendaService(
            IVendaRepository repository,
            IMapper mapper,
            INotificador notificador, 
            IVendaRepository vendaRepository) : base(repository, mapper, notificador)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task Adicionar(VendaViewModel viewModel)
        {
            var entity = _mapper.Map<Domain.Models.Venda>(viewModel);
            entity.GetValorTotal();

            await _vendaRepository.Adicionar(entity);
        }

        public async Task Alterar(VendaViewModel viewModel)
        {
            var entity = _mapper.Map<Domain.Models.Venda>(viewModel);
            entity.GetValorTotal();

            await _vendaRepository.Alterar(entity);
        }

        public async Task<IEnumerable<VendaDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VendaDto>>(await _vendaRepository.ObterTodos());
        }

        public async Task<VendaDto> Selecionar(decimal id)
        {
            return _mapper.Map<VendaDto>(await _vendaRepository.Selecionar(id));
        }

    }
}
