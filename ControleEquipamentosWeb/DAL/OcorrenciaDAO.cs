using ControleEquipamentosWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.DAL
{
    public class OcorrenciaDAO
    {
        private readonly Context _context;

        public OcorrenciaDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Ocorrencia o)
        {
            _context.Ocorrencias.Add(o);
            _context.SaveChanges();
            return true;
        }

        public Ocorrencia BuscarPorId(int? id)
        {
            return _context.Ocorrencias.FirstOrDefault(x => x.Id == id);
        }

        public List<Ocorrencia> ListarTodos()
        {
            return _context.Ocorrencias.ToList();
        }

        public void Remover(int? id)
        {
            _context.Ocorrencias.Remove(BuscarPorId(id));
        }

        public void Alterar(Ocorrencia o)
        {
            _context.Ocorrencias.Update(o);
            _context.SaveChanges();
        }
    }
}
