using BaseProject.Core.Application.Controller;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Usuario;
using BaseProject.Domain.Interop.ViewModels.Usuario;
using Microsoft.AspNetCore.Mvc;
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

            return CustomResponse(await _service.ObterTodos<UsuarioDto>());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _service.Selecionar<UsuarioDto>(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreateViewModel usuario)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Adicionar(usuario);

            return CustomResponse("Usuário adicionado com sucesso.");

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UsuarioUpdateViewModel usuario)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Alterar<UsuarioUpdateViewModel>(usuario);

            return CustomResponse("Usuário alterado com sucesso.");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Remover(id);

            return CustomResponse("Usuário excluido com sucesso.");
        }

    }
}
