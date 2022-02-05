using AutoMapper;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Core.Domain.Models;
using BaseProject.Core.Helpers;
using BaseProject.Core.Service;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.ViewModels.Usuario;
using System.Threading.Tasks;

namespace BaseProject.Service.Usuario
{
    public class UsuarioService : Service<Domain.Models.Usuario>, IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(
            IUsuarioRepository repository, 
            IMapper mapper,
            INotificador notificador) : base(repository, mapper, notificador)
        {
            _usuarioRepository = repository;
        }

        public async Task Adicionar(UsuarioCreateViewModel viewModel)
        {
            viewModel.Senha = ConvertMD5.CriptografiaMD5(viewModel.Senha);
            await base.Adicionar<UsuarioCreateViewModel>(viewModel);
        }

        public async Task Alterar(UsuarioUpdateViewModel viewModel)
        {
            if (viewModel == null) {
                _notificador.Handle(new Notificacao("Valor inválido!"));
                return;
            }

            var usuario = await _usuarioRepository.Selecionar(viewModel.Id);

            if (viewModel == null)
            {
                _notificador.Handle(new Notificacao("Usuário não encontrado!"));
                return;
            }

            
            if (viewModel.Senha != usuario.Senha)
                viewModel.Senha = ConvertMD5.CriptografiaMD5(viewModel.Senha);

            await base.Alterar<UsuarioUpdateViewModel>(viewModel);

        }
    }
}
