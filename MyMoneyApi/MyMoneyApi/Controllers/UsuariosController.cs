using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyMoneyApi.Models;
using MyMoneyApi.Repositorio;
using MyMoneyApi.Services;

namespace MyMoneyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _repo;
        private readonly IConfiguration _config;

        public UsuariosController(IUsuarioRepositorio repositorio, IConfiguration configuration)
        {
            _repo = repositorio;
            _config = configuration;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _repo.GetAll();
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(int id)
        {
            var usuario = _repo.Find(id);
            if (usuario == null)
                return NotFound();
            return new ObjectResult(usuario);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] Usuario usuario)
        {

            if (usuario == null)
            {
                return BadRequest();
            }
            _repo.Add(usuario);
            return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.Id)
            {
                return BadRequest();
            }
            var _usuario = _repo.Find(id);
            if (_usuario == null)
                return NotFound();
            _usuario.Nome = usuario.Nome;
            _usuario.Email = usuario.Email;
            _repo.Update(_usuario);

            return new NoContentResult();
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _repo.Find(id);
            if (usuario == null)
                return NotFound();

            _repo.Remove(id);
            return new NoContentResult();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            var _usuario = _repo.Login(usuario);
            if (_usuario == null)
                return NotFound();

            TokenServices tokenService = new TokenServices(_config);
            var token = tokenService.RequestToken(_usuario);
            _usuario.Senha = "";
            return Ok(new
            {
                usuario = _usuario,
                token = token,
            });
        }
    }
}
