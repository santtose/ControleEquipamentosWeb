using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    public class ItemEmprestimo
    {
        public int Id { get; set; }
        public Emprestimo Emprestimo { get; set; }
        public int Quantidade { get; set; }
        public string CestaId { get; set; }
    }
}
