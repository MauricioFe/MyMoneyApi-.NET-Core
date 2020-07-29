using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio
{
    public interface IMovimentacaoRepositorio
    {
        IEnumerable<Movimentacao> GetAll();
        Movimentacao Find(long id);
        void Add(Movimentacao movimentacao);
        void Update(Movimentacao movimentacao);
        void Remove(long id);
    }
}
