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
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepositorio _repo;

        public CategoriasController(ICategoriaRepositorio repositorio)
        {
            _repo = repositorio;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public IEnumerable<Categoria> GetAll()
        {
            return _repo.GetAll();
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}", Name = "GetCategoria")]
        public IActionResult GetById(int id)
        {
            var categoria = _repo.Find(id);
            if (categoria == null)
                return NotFound();
            return new ObjectResult(categoria);
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public IActionResult Create([FromBody] Categoria categoria)
        {

            if (categoria == null)
            {
                return BadRequest();
            }
            _repo.Add(categoria);
            return CreatedAtRoute("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Categoria categoria)
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

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = _repo.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            _repo.Remove(id);
            return new NoContentResult();
        }
    }
}
