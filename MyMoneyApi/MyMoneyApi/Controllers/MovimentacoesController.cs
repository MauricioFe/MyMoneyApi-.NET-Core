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
    public class MovimentacoesController : Controller
    {
        private readonly IMovimentacaoRepositorio _repo;

        public MovimentacoesController(IMovimentacaoRepositorio repositorio)
        {
            _repo = repositorio;
        }

        // GET: api/<MovimentacoesController>
        [HttpGet]
        public IEnumerable<Movimentacao> GetAll()
        {
            return _repo.GetAll();
        }

        // GET api/<MovimentacoesController>/5
        [HttpGet("{id}", Name = "GetMovimentacao")]
        public IActionResult GetById(int id)
        {
            var movimentacao = _repo.Find(id);
            if (movimentacao == null)
                return NotFound();
            return new ObjectResult(movimentacao);
        }

        // POST api/<MovimentacoesController>
        [HttpPost]
        public IActionResult Create([FromBody] Movimentacao movimentacao)
        {

            if (movimentacao == null)
            {
                return BadRequest();
            }
            _repo.Add(movimentacao);
            return CreatedAtRoute("GetMovimentacao", new { id = movimentacao.Id }, movimentacao);
        }

        // PUT api/<MovimentacoesController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Movimentacao movimentacao)
        {
            if (movimentacao == null || id != movimentacao.Id)
            {
                return BadRequest();
            }
            var _movimentacao = _repo.Find(id);
            if (_movimentacao == null)
                return NotFound();
            _movimentacao.Descricao = movimentacao.Descricao;
            _repo.Update(_movimentacao);

            return new NoContentResult();
        }

        // DELETE api/<MovimentacoesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
