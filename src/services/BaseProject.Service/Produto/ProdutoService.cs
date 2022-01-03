using AutoMapper;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Core.Service;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;

namespace BaseProject.Service.Produto
{
    public class ProdutoService : Service<Domain.Models.Produto>, IProdutoService
    {
        public ProdutoService(
            IProdutoRepository repository, 
            IMapper mapper, 
            INotificador notificador) : base(repository, mapper, notificador)
        {
        }
    }
}
