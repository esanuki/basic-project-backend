using BaseProject.Core.Domain.Models;
using System.Collections.Generic;

namespace BaseProject.Core.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        IList<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
