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
    public class TipoMovimentacaoController : Controller
    {
        private readonly ITipoMovimentacaoRepositorio _repo;

        public TipoMovimentacaoController(ITipoMovimentacaoRepositorio repositorio)
        {
            _repo = repositorio;
        }

        // GET: api/<TipoMovimentacaoController>
        [HttpGet]
        public IEnumerable<TipoMovimentacao> GetAll()
        {
            return _repo.GetAll();
        }

        // GET api/<TipoMovimentacaoController>/5
        [HttpGet("{id}", Name = "GetTipoMovimentacao")]
        public IActionResult GetById(int id)
        {
            var tipoMovimentacao = _repo.Find(id);
            if (tipoMovimentacao == null)
                return NotFound();
            return new ObjectResult(tipoMovimentacao);
        }

        // POST api/<TipoMovimentacaoController>
        [HttpPost]
        public IActionResult Create([FromBody] TipoMovimentacao tipoMovimentacao)
        {

            if (tipoMovimentacao == null)
            {
                return BadRequest();
            }
            _repo.Add(tipoMovimentacao);
            return CreatedAtRoute("GetTipoMovimentacao", new { id = tipoMovimentacao.Id }, tipoMovimentacao);
        }

        // PUT api/<TipoMovimentacaoController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]TipoMovimentacao tipoMovimentacao)
        {
            if (tipoMovimentacao == null || id != tipoMovimentacao.Id)
            {
                return BadRequest();
            }
            var _tipoMovimentacao = _repo.Find(id);
            if (_tipoMovimentacao == null)
                return NotFound();
            _tipoMovimentacao.Descricao = tipoMovimentacao.Descricao;
            _repo.Update(_tipoMovimentacao);

            return new NoContentResult();
        }

        // DELETE api/<TipoMovimentacaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
