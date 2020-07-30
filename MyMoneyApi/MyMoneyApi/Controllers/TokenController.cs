using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyMoneyApi.Models;

namespace MyMoneyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TokenController(IConfiguration configuration)
        {
            _config = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario request)
        {
            if (request.Email == "mauricio.lacerdaml@gmail.com" && request.Senha == "86257765")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Nome)
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
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest("Credenciais inválidas");
        }
    }
}
