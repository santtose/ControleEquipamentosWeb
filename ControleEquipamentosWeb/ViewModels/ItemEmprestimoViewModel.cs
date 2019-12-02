using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.ViewModels
{
    public class ItemEmprestimoViewModel
    {
        public int EquipamentoId { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public bool Selecionado { get; set; }
    }
}
