using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    public class ItemEmprestimo
    {
        public int Id { get; set; }
        public int EquipamentoId { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int EmprestimoId { get; set; }
    }
}
