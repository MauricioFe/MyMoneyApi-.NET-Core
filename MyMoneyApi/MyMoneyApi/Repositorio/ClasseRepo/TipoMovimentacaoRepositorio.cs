using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio.ClasseRepo
{
    public class TipoMovimentacaoRepositorio : ITipoMovimentacaoRepositorio
    {
        private readonly MyMoneyDBContext _context;

        public TipoMovimentacaoRepositorio(MyMoneyDBContext context)
        {
            _context = context;
        }
        public void Add(TipoMovimentacao tipoTipoMovimentacao)
        {
            _context.TipoMovimentacao.Add(tipoTipoMovimentacao);
           _context.SaveChanges();
        }

        public TipoMovimentacao Find(long id)
        {
            return _context.TipoMovimentacao.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TipoMovimentacao> GetAll()
        {
            return _context.TipoMovimentacao.ToList();
        }

        public void Remove(long id)
        {
            var tipoTipoMovimentacao = Find(id);
            _context.TipoMovimentacao.Remove(tipoTipoMovimentacao);
            _context.SaveChanges();
        }

        public void Update(TipoMovimentacao tipoTipoMovimentacao)
        {
            _context.TipoMovimentacao.Update(tipoTipoMovimentacao);
            _context.SaveChanges();
        }
    }
}
