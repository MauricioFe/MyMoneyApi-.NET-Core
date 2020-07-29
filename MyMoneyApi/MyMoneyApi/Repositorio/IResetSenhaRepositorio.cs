using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio
{
    public interface IResetSenhaRepositorio
    {
        IEnumerable<ResetSenha> GetAll();
        ResetSenha Find(long id);
        void Add(ResetSenha resetSenha);
        void Update(ResetSenha resetSenha);
        void Remove(long id);
    }
}
