using BaseProject.Core.Application.Controller;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Usuario;
using BaseProject.Domain.Interop.ViewModels;
using BaseProject.Domain.Interop.ViewModels.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseProject.Application.Controllers
{

    [Route("api/usuario")]   
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _service;

        public UsuarioController(INotificador notificador,IUsuarioService service) : base(notificador)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                return CustomResponse(await _service.ObterTodos<UsuarioDto>());
            } catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                return CustomResponse(await _service.Selecionar<UsuarioDto>(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreateViewModel usuario)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                await _service.Adicionar(usuario);

                return CustomResponse("Usuário adicionado com sucesso.");
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UsuarioUpdateViewModel usuario)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                await _service.Alterar<UsuarioUpdateViewModel>(usuario);

                return CustomResponse("Usuário alterado com sucesso.");
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                await _service.Remover(id);

                return CustomResponse("Usuário excluido com sucesso.");
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
