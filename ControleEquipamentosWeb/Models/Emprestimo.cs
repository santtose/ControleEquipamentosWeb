using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public bool StatusEmprestimo { get; set; } = false;

        [Display(Name = "Data Devolução")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataDevolucao { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data Empréstimo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataEmprestimo { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data Prevista Devolução")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPrevistaDevolucao { get; set; }
        public Pessoa Operador { get; set; }
        public Pessoa Usuario { get; set; }
        public List<ItemEmprestimo> Equipamentos { get; set; }
    }
}
