using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMoneyApi.Models;
using MyMoneyApi.Repositorio;

namespace MyMoneyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetSenhaController : Controller
    {
        private readonly IResetSenhaRepositorio _repo;

        public ResetSenhaController(IResetSenhaRepositorio repositorio)
        {
            _repo = repositorio;
        }

        // GET: api/<ResetSenhaController>
        [HttpGet]
        public IEnumerable<ResetSenha> GetAll()
        {
            return _repo.GetAll();
        }

        // GET api/<ResetSenhaController>/5
        [HttpGet("{id}", Name = "GetResetSenha")]
        public IActionResult GetById(int id)
        {
            var categoria = _repo.Find(id);
            if (categoria == null)
                return NotFound();
            return new ObjectResult(categoria);
        }

        // POST api/<ResetSenhaController>
        [HttpPost]
        public IActionResult Create([FromBody] ResetSenha categoria)
        {

            if (categoria == null)
            {
                return BadRequest();
            }
            _repo.Add(categoria);
            return CreatedAtRoute("GetResetSenha", new { id = categoria.Id }, categoria);
        }

        // PUT api/<ResetSenhaController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ResetSenha categoria)
        {
            if (categoria == null || id != categoria.Id)
            {
                return BadRequest();
            }
            var _categoria = _repo.Find(id);
            if (_categoria == null)
                return NotFound();
            _categoria.Descricao = categoria.Descricao;
            _repo.Update(_categoria);

            return new NoContentResult();
        }

        // DELETE api/<ResetSenhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
