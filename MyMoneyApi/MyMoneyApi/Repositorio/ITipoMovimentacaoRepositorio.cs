using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio
{
    public interface ITipoMovimentacaoRepositorio
    {
        IEnumerable<TipoMovimentacao> GetAll();
        TipoMovimentacao Find(long id);
        void Add(TipoMovimentacao tipoMovimentacao);
        void Update(TipoMovimentacao tipoMovimentacao);
        void Remove(long id);
    }
}
