using BaseProject.Core.Domain.Interfaces;
using BaseProject.Core.Domain.Models;
using BaseProject.Core.Helpers;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Domain.Interop.Dtos.Login;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BaseProject.Service.Login
{
    public class LoginService : ILoginService
    {
        private IUsuarioRepository _usuarioRepository;
        private SigningConfiguration _signingConfiguration;
        private TokenConfigurations _tokenConfigurations;
        private INotificador _notificador;

        public LoginService(
            IUsuarioRepository usuarioRepository,
            SigningConfiguration signingConfiguration,
            TokenConfigurations tokenConfigurations, 
            INotificador notificador)
        {
            _usuarioRepository = usuarioRepository;
            _signingConfiguration = signingConfiguration;
            _tokenConfigurations = tokenConfigurations;
            _notificador = notificador;
        }

        public async Task<object> ObterPorLogin(LoginViewModel login)
        {
            var usuario = new Domain.Models.Usuario();

            if (login != null && 
                !string.IsNullOrEmpty(login.Email) &&
                !string.IsNullOrEmpty(login.Senha))
            {
                usuario = (await _usuarioRepository.ObterTodosQueryable())
                                .FirstOrDefault(u => u.Email.Equals(login.Email) &&
                                                    u.Senha.Equals(ConvertMD5.CriptografiaMD5(login.Senha)));

                if (usuario != null)
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(usuario.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        });
                    DateTime createTime = DateTime.Now;
                    DateTime expirationDate = createTime + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    var token = Token.CreateToken(
                        _tokenConfigurations,
                        _signingConfiguration,
                        identity,
                        createTime,
                        expirationDate,
                        handler);

                    return SuccessObject(createTime, expirationDate, token, usuario);
                }  
            }

            _notificador.Handle(new Notificacao("Falha ao autenticar"));
            return null;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, Domain.Models.Usuario usuario)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = usuario.Email,
                message = "Usuario logado com sucesso"
            };
        }
    }
}
