using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<Categoria> GetAll();
        Categoria Find(long id);
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Remove(long id);
    }
}
