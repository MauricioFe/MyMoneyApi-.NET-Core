using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio
{
    interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> GetAll();
        Usuario Find(long id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Remove(long id);
    }
}
