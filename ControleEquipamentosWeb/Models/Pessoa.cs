using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    [Table("Pessoas")]
    public class Pessoa
    {
        public int Id { get; set; }
        [MaxLength(200, ErrorMessage ="Máximo de 200 caracteres atingidos.")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres.")]
        public string Nome { get; set; }
        public DateTime Aniversario { get; set; }
        public string Usuario { get; set; }
        public string CPF { get; set; }
        public bool Admin { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
