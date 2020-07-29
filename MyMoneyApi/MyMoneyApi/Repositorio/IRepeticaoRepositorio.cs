using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio
{
    public interface IRepeticaoRepositorio
    {
        IEnumerable<Repeticao> GetAll();
        Repeticao Find(long id);
        void Add(Repeticao repeticao);
        void Update(Repeticao repeticao);
        void Remove(long id);
    }
}
