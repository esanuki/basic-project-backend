using BaseProject.Core.Domain.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BaseProject.Core.Helpers
{
    public static class Token
    {
        public static string CreateToken(
            TokenConfigurations tokenConfigurations,
            SigningConfiguration signingConfiguration,
            ClaimsIdentity identity, 
            DateTime createTime, 
            DateTime expirationDate, 
            JwtSecurityTokenHandler handler
            )
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createTime,
                Expires = expirationDate
            });

            return handler.WriteToken(securityToken);
        }
    }
}
