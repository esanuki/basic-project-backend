using BaseProject.Core.Application.Controller;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Produto;
using BaseProject.Domain.Interop.ViewModels.Produto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseProject.Application.Controllers
{
    [Route("api/produto")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(
            INotificador notificador, 
            IProdutoService produtoService) : base(notificador)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _produtoService.ObterTodos<ProdutoDto>());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _produtoService.Selecionar<ProdutoDto>(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoViewModel produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Adicionar(produto);

            return CustomResponse("Produto adicionado com sucesso.");
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProdutoViewModel produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Alterar<ProdutoViewModel>(produto);

            return CustomResponse("Produto alterado com sucesso.");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Remover(id);

            return CustomResponse("Produto excluido com sucesso.");
        }
    }
}
