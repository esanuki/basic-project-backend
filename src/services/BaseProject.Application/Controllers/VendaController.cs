using BaseProject.Core.Application.Controller;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Venda;
using BaseProject.Domain.Interop.ViewModels.Venda;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseProject.Application.Controllers
{
    [Route("api/venda")]
    public class VendaController : BaseController
    {
        public IVendaService _vendaService { get; set; }
        public VendaController(INotificador notificador, IVendaService vendaService) : base(notificador)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _vendaService.ObterTodos());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _vendaService.Selecionar(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VendaViewModel venda)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _vendaService.Adicionar(venda);

            return CustomResponse("Venda Efetuada com sucesso.");
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] VendaViewModel venda)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _vendaService.Alterar(venda);

            return CustomResponse("Venda alterada com sucesso.");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _vendaService.Remover(id);

            return CustomResponse("Venda excluida com sucesso.");
        }
    }
}
