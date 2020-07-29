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
            var resetSenha = _repo.Find(id);
            if (resetSenha == null)
                return NotFound();
            return new ObjectResult(resetSenha);
        }

        // POST api/<ResetSenhaController>
        [HttpPost]
        public IActionResult Create([FromBody] ResetSenha resetSenha)
        {

            if (resetSenha == null)
            {
                return BadRequest();
            }
            _repo.Add(resetSenha);
            return CreatedAtRoute("GetResetSenha", new { id = resetSenha.Id }, resetSenha);
        }

        // PUT api/<ResetSenhaController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ResetSenha resetSenha)
        {
            if (resetSenha == null || id != resetSenha.Id)
            {
                return BadRequest();
            }
            var _resetSenha = _repo.Find(id);
            if (_resetSenha == null)
                return NotFound();
            
            _repo.Update(_resetSenha);

            return new NoContentResult();
        }

        // DELETE api/<ResetSenhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
