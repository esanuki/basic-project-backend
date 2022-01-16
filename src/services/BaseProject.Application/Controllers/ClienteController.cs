using BaseProject.Core.Application.Controller;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Cliente;
using BaseProject.Domain.Interop.ViewModels.Cliente;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseProject.Application.Controllers
{
    [Route("api/cliente")]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(
            INotificador notificador, 
            IClienteService clienteService) : base(notificador)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _clienteService.ObterTodos<ClienteDto>());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _clienteService.SelecionarComEndereco(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreateViewModel cliente)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Adicionar(cliente);

            return CustomResponse("Cliente adicionado com sucesso.");
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ClienteUpdateViewModel cliente)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Alterar<ClienteUpdateViewModel>(cliente);

            return CustomResponse("Cliente alterado com sucesso.");
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Remover(id);

            return CustomResponse("Cliente excluido com sucesso.");
        }
    }
}
