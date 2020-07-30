using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyMoneyApi.Services
{
    public class TokenServices
    {
        private readonly IConfiguration _config;

        public TokenServices(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string RequestToken(Usuario request)
        {

            var tokenHadler = new JwtSecurityTokenHandler();

            var claims = new[]
            {
                    new Claim(ClaimTypes.Name, request.Email)
                };

            //Recebe uma instancia da classe SymmetricSecuriryKey. Armazenando a chave de criptografia usada na criação do token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]));

            //Recebe um objeto do tipo SigninCredentials contendo a chave de criptografia e o algoritimo de segurança empregados na geração
            //de assinaturas digitais para tokens.

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Mauricio",
                audience: "Mauricio",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return tokenHadler.WriteToken(token);

        }
    }
}
