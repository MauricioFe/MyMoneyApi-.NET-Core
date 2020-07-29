using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio.ClasseRepo
{
    public class MovimentacaoRepositorio : IMovimentacaoRepositorio
    {
        private readonly MyMoneyDBContext _context;

        public MovimentacaoRepositorio(MyMoneyDBContext context)
        {
            _context = context;
        }
        public void Add(Movimentacao movimentacao)
        {
            _context.Movimentacao.Add(movimentacao);
            _context.SaveChanges();
        }

        public Movimentacao Find(long id)
        {
            return _context.Movimentacao.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Movimentacao> GetAll()
        {
            return _context.Movimentacao.ToList();
        }

        public void Remove(long id)
        {
            var movimentacao = Find(id);
            _context.Movimentacao.Remove(movimentacao);
            _context.SaveChanges();
        }

        public void Update(Movimentacao movimentacao)
        {
            _context.Movimentacao.Update(movimentacao);
            _context.SaveChanges();
        }
    }
}
