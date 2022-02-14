using AutoMapper;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Core.Service;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Venda;
using BaseProject.Domain.Interop.ViewModels.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                var entity = _mapper.Map<Domain.Models.Venda>(viewModel);
                entity.GetValorTotal();

                var vendaItens = await _vendaRepository.ObterVendaItensPorVenda(entity.Id);
                if (vendaItens.Count() > 0)
                    await _vendaRepository.ExcluirVendaItens(vendaItens);

                await _vendaRepository.Alterar(entity);
            } catch(Exception e)
            {
                throw e;
            }
            
        }

        public async Task<IEnumerable<VendaListDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VendaListDto>>(await _vendaRepository.ObterTodos());
        }

        public async Task<VendaDto> Selecionar(decimal id)
        {
            return _mapper.Map<VendaDto>(await _vendaRepository.Selecionar(id));
        }

    }
}
