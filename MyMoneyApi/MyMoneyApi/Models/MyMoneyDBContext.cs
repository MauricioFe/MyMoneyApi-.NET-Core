using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Models
{
    public class MyMoneyDBContext : DbContext
    {
        public MyMoneyDBContext(DbContextOptions<MyMoneyDBContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoMovimentacao> TipoMovimentacao { get; set; }
        public DbSet<Repeticao> Repeticao { get; set; }
        public DbSet<ResetSenha> ResetSenha { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
