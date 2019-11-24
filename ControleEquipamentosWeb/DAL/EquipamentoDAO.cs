using ControleEquipamentosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.DAL
{
    public class EquipamentoDAO
    {
        private readonly Context _context;

        public EquipamentoDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Equipamento eq)
        {
            if (BuscarPorNome(eq) == null)
            {
                _context.Equipamentos.Add(eq);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Equipamento BuscarPorNome(Equipamento eq)
        {
            return _context.Equipamentos.FirstOrDefault(x => x.Descricao.Equals(eq.Descricao));
        }

        public Equipamento BuscarPorId(int? id)
        {
            return _context.Equipamentos.FirstOrDefault(x => x.Id == id);
        }

        public List<Equipamento> ListarTodos()
        {
            return _context.Equipamentos.ToList();
        }

        public void Remover(int? id)
        {
            _context.Equipamentos.Remove(BuscarPorId(id));
        }

        public void Alterar(Equipamento eq)
        {
            _context.Equipamentos.Update(eq);
            _context.SaveChanges();
        }
    }
}
