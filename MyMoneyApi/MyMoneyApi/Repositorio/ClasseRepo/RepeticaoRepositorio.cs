using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio.ClasseRepo
{
    public class RepeticaoRepositorio : IRepeticaoRepositorio
    {
        private readonly MyMoneyDBContext _context;

        public RepeticaoRepositorio(MyMoneyDBContext context)
        {
            _context = context;
        }
        public void Add(Repeticao repeticao)
        {
            _context.Repeticao.Add(repeticao);
            _context.SaveChanges();
        }

        public Repeticao Find(long id)
        {
            return _context.Repeticao.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Repeticao> GetAll()
        {
            return _context.Repeticao.ToList();
        }

        public void Remove(long id)
        {
            var repeticao = Find(id);
            _context.Repeticao.Remove(repeticao);
            _context.SaveChanges();
        }

        public void Update(Repeticao repeticao)
        {
            _context.Repeticao.Update(repeticao);
            _context.SaveChanges();
        }

    }
}
