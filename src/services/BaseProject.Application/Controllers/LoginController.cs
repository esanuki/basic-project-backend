using BaseProject.Core.Application.Controller;
using BaseProject.Core.Domain.Interfaces;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseProject.Application.Controllers
{
    [Route("api/login")]
    public class LoginController : BaseController
    {
        private ILoginService _loginService;
        public LoginController(
            INotificador notificador, 
            ILoginService loginService) : base(notificador)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("entrar")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginViewModel login)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            return CustomResponse(await _loginService.ObterPorLogin(login));
        }

    }
}
