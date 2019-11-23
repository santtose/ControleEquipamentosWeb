using ControleEquipamentosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.DAL
{
    public class PessoaDAO //: IRepository<Pessoa>
    {
        private readonly Context _context;

        public PessoaDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Pessoa p)
        {
            if(BuscarPessoaPorNome(p) == null)
            {
                _context.Pessoas.Add(p);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Pessoa BuscarPessoaPorNome(Pessoa p)
        {
            return _context.Pessoas.FirstOrDefault(x => x.Nome.Equals(p.Nome));
        }

        public Pessoa BuscarPorId(int? id)
        {
            return _context.Pessoas.FirstOrDefault(x => x.Id == id);
        }

        public List<Pessoa> ListarTodos()
        {
            return _context.Pessoas.ToList();
        }

        public void Remover(int? id)
        {
            _context.Pessoas.Remove(BuscarPorId(id));
        }

        public void Alterar(Pessoa p)
        {
            _context.Pessoas.Update(p);
            _context.SaveChanges();
        }
    }
}
