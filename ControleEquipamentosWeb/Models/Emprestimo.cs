using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public bool StatusEmprestimo { get; set; } = false;
        public DateTime DataDevolucao { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public Pessoa Operador { get; set; }
        public Pessoa Usuario { get; set; }
        public Equipamento Equipamento { get; set; }
        public List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();
    }
}
