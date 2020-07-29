using MyMoneyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Repositorio.ClasseRepo
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly MyMoneyDBContext _context;

        public CategoriaRepositorio(MyMoneyDBContext context)
        {
            _context = context;
        }
        public void Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public Categoria Find(long id)
        {
            return _context.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias.ToList();
        }

        public void Remove(long id)
        {
            var categoria = Find(id);
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }
    }
}
