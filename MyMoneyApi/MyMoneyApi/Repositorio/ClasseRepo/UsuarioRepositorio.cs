using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio.ClasseRepo
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MyMoneyDBContext _context;

        public UsuarioRepositorio(MyMoneyDBContext context)
        {
            _context = context;
        }
        public void Add(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario Find(long id)
        {
            return _context.Usuario.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }

        public Usuario Login(Usuario usuario)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == usuario.Email && u.Senha == usuario.Senha);
        }

        public void Remove(long id)
        {
            var usuario = Find(id);
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }
    }
}
