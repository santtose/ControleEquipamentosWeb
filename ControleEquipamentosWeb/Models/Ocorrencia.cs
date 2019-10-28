using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public Equipamento Equipamento { get; set; }
        public int OrdemDeServico { get; set; }
        public DateTime PrevisaoRetorno { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
