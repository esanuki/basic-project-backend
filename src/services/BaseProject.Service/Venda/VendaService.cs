using AutoMapper;
using BaseProject.Core.Data.Interfaces;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Core.Service;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Service.Venda
{
    public class VendaService : Service<Domain.Models.Venda>, IVendaService
    {
        public VendaService(
            IVendaRepository repository, 
            IMapper mapper, 
            INotificador notificador) : base(repository, mapper, notificador)
        {
        }

    }
}
