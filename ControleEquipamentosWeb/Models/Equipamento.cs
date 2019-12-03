using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NumeroRegistro { get; set; }
        public Pessoa Operador { get; set; }
        public int Contador { get; set; }
        public bool Inativo { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Criado Em:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
