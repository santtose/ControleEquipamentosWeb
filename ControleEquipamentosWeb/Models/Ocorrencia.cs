using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public bool Devolvido { get; set; }
        public string Descricao { get; set; }
        public Equipamento Equipamento { get; set; }
        public int OrdemDeServico { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data Ocorrência")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataOcorrencia { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Previsão Retorno")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PrevisaoRetorno { get; set; }
        
        [Display(Name = "Data Devolução")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataDevolucao { get; set; }
    }
}
