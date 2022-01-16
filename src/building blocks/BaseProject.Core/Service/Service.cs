using AutoMapper;
using BaseProject.Core.Data.Interfaces;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Core.Domain.Models;
using BaseProject.Core.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseProject.Core.Service
{
    public class Service<T> : IService<T> where T : BaseModel
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;
        protected readonly INotificador _notificador;

        public Service(
            IRepository<T> repository, 
            IMapper mapper,
            INotificador notificador)
        {
            _repository = repository;
            _mapper = mapper;
            _notificador = notificador;
        }

        public virtual async Task<IEnumerable<Dto>> ObterTodos<Dto>()
        {
            var result = await _repository.ObterTodos();
            return _mapper.Map<IEnumerable<Dto>>(result);
        }

        public virtual async Task<Dto> Selecionar<Dto>(decimal id)
        {
            var result = await _repository.Selecionar(id);
            return _mapper.Map<Dto>(result);
        }

        public virtual async Task Adicionar<ViewModel>(ViewModel viewModel)
        {
            var entity = _mapper.Map<T>(viewModel);
            await _repository.Adicionar(entity);
        }

        public virtual async Task Alterar<ViewModel>(ViewModel viewModel)
        {
            var entity = _mapper.Map<T>(viewModel);

            if (!entity.EhValido())
            {
                entity.ValidationResult.Errors.ForEach(e => _notificador.Handle(new Notificacao(e.ErrorMessage)));
                return;
            }

            await _repository.Alterar(entity);
        }

        public virtual async Task Remover(decimal id)
        {
            await _repository.Remover(id);
        }

    }
}
