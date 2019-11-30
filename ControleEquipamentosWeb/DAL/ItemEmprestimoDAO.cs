using ControleEquipamentosWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.DAL
{
    public class ItemEmprestimoDAO
    {
        private readonly Context _context;

        public ItemEmprestimoDAO(Context context)
        {
            _context = context;
        }

        public ItemEmprestimo BuscarPorId(int? id)
        {
            return _context.ItemEmprestimos.Find(id);
        }

        public bool Cadastrar(ItemEmprestimo i)
        {
            _context.ItemEmprestimos.Add(i);
            _context.SaveChanges();
            return true;
        }

        public List<ItemEmprestimo> ListarTodos()
        {
            return _context.ItemEmprestimos.ToList();
        }

        public List<ItemEmprestimo> ListarItensPorCestaId(string cestaId)
        {
            return _context.ItemEmprestimos.Include(x => x.Emprestimo.Equipamentos).Where(x => x.CestaId.Equals(cestaId)).ToList();
        }
    }
}
