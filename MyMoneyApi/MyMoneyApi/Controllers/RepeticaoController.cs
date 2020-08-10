using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMoneyApi.Models;
using MyMoneyApi.Repositorio;

namespace MyMoneyApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepeticaoController : Controller
    {
        private readonly IRepeticaoRepositorio _repo;

        public RepeticaoController(IRepeticaoRepositorio repositorio)
        {
            _repo = repositorio;
        }

        // GET: api/<RepeticaoController>
        [HttpGet]
        public IEnumerable<Repeticao> GetAll()
        {
            return _repo.GetAll();
        }

        // GET api/<RepeticaoController>/5
        [HttpGet("{id}", Name = "GetRepeticao")]
        public IActionResult GetById(int id)
        {
            var repeticao = _repo.Find(id);
            if (repeticao == null)
                return NotFound();
            return new ObjectResult(repeticao);
        }

        // POST api/<RepeticaoController>
        [HttpPost]
        public IActionResult Create([FromBody] Repeticao repeticao)
        {

            if (repeticao == null)
            {
                return BadRequest();
            }
            _repo.Add(repeticao);
            return CreatedAtRoute("GetRepeticao", new { id = repeticao.Id }, repeticao);
        }

        // PUT api/<RepeticaoController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Repeticao repeticao)
        {
            if (repeticao == null || id != repeticao.Id)
            {
                return BadRequest();
            }
            var _repeticao = _repo.Find(id);
            if (_repeticao == null)
                return NotFound();
            _repeticao.Descricao = repeticao.Descricao;
            _repeticao.Periodo = repeticao.Periodo;
            _repeticao.NumOcorrencias= repeticao.NumOcorrencias;
            _repeticao.NumParcelas = repeticao.NumParcelas;
            _repo.Update(_repeticao);

            return new NoContentResult();
        }

        // DELETE api/<RepeticaoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var repeticao = _repo.Find(id);
            if (repeticao == null)
                return NotFound();
            _repo.Remove(id);
            return new NoContentResult();
        }
    }
}
