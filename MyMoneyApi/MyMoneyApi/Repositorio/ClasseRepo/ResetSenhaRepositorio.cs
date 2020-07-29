using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio.ClasseRepo
{
    public class ResetSenhaRepositorio : IResetSenhaRepositorio
    {
        private readonly MyMoneyDBContext _context;

        public ResetSenhaRepositorio(MyMoneyDBContext context)
        {
            _context = context;
        }
        public void Add(ResetSenha resetSenha)
        {
            _context.ResetSenha.Add(resetSenha);
            _context.SaveChanges();
        }

        public ResetSenha Find(long id)
        {
            return _context.ResetSenha.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<ResetSenha> GetAll()
        {
            return _context.ResetSenha.ToList();
        }

        public void Remove(long id)
        {
            var resetSenha = Find(id);
            _context.ResetSenha.Remove(resetSenha);
            _context.SaveChanges();
        }

        public void Update(ResetSenha resetSenha)
        {
            _context.ResetSenha.Update(resetSenha);
            _context.SaveChanges();
        }

    }
}
