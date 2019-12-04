using ControleEquipamentosWeb.Models;
using Microsoft.EntityFrameworkCore;
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
            _context.Equipamentos.Add(eq);
            _context.SaveChanges();
            return true;
        }

        public Equipamento BuscarPorId(int? id)
        {
            return _context.Equipamentos.FirstOrDefault(x => x.Id == id);
        }

        public List<Equipamento> ListarTodos()
        {
            return _context.Equipamentos.ToList();
        }

        public List<Equipamento> ListarDisponiveis()
        {
            var equipamentos = _context.Equipamentos.Where(x => !x.Inativo).ToList();

            return equipamentos;
        }

        public List<ItemEmprestimo> ListarItensDeEmprestimo(int id)
        {
            var lista = _context.ItemEmprestimos.Where(x => x.EmprestimoId == id).ToList();

            return lista;
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
