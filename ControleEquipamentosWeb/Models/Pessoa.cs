using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Aniversario { get; set; }
        public string Usuario { get; set; }
        public string CPF { get; set; }
        public bool Admin { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
