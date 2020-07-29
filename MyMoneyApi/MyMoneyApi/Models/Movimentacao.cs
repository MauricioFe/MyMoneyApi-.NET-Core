using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoneyApi.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Date { get; set; }
        public string Observacoes{ get; set; }
        public int Categoria_id { get; set; }
        public int TipoMovimentacao_id { get; set; }
        public int Repeticao_id { get; set; }
        public int Usuario_id { get; set; }
    }
}
