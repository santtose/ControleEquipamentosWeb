using ControleEquipamentosWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.DAL
{
    public class EmprestimoDAO
    {
        private readonly Context _context;

        public EmprestimoDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Emprestimo emp)
        {
            _context.Emprestimos.Add(emp);
            _context.SaveChanges();
            return true;
        }

        public Emprestimo BuscarPorId(int? id)
        {
            return _context.Emprestimos.FirstOrDefault(x => x.Id == id);
        }

        public List<Emprestimo> ListarTodos()
        {
            return _context.Emprestimos.ToList();
        }

        public List<Emprestimo> ListarEmprestimosAtrasados() => _context.Emprestimos.Where(x => x.DataPrevistaDevolucao < DateTime.Now).ToList();

        //trocar por uma viewmodel de pesquisa
        public List<Emprestimo> ListarComParametros(int? idUsuario, int? idOperador, DateTime? dataInicio, DateTime? dataFim,
            DateTime? dataPrevistaDevolucaoInicio, DateTime? dataPrevistaDevolucaoFim, int? idEquipamento, bool atrasadosApenas, bool excluiFinalizados)
        {
            if (dataFim == null)
            {
                dataFim = DateTime.Now;
            }

            List<Emprestimo> lista = _context.Emprestimos.Include(eq => eq.Equipamentos).Include(u => u.Usuario).Include(o => o.Operador).Where(x => x.DataEmprestimo <= dataFim).ToList();

            if (atrasadosApenas)
                lista = lista.Where(a => a.DataPrevistaDevolucao < DateTime.Now).ToList();

            if (excluiFinalizados)
                lista = lista.Where(f => !f.StatusEmprestimo).ToList();

            if (dataInicio != null)
                lista = lista.Where(c => c.DataEmprestimo >= dataInicio).ToList();

            if (dataPrevistaDevolucaoInicio != null)
                lista = lista.Where(c => c.DataPrevistaDevolucao >= dataPrevistaDevolucaoInicio).ToList();

            if (dataPrevistaDevolucaoFim != null)
                lista = lista.Where(c => c.DataPrevistaDevolucao <= dataPrevistaDevolucaoFim).ToList();

            //if (idEquipamento != null)
            //{
            //    Equipamento equipamento = _context.Equipamentos.Find(idEquipamento);
            //    lista = lista.FindAll(c => c.Equipamentos.Contains(equipamento)).ToList();
            //}

            if (idUsuario != null)
            {
                Pessoa pessoaUsuario = _context.Pessoas.Find(idUsuario);
                lista = lista.Where(c => c.Usuario == pessoaUsuario).ToList();
            }

            if (idOperador != null)
            {
                Pessoa pessoaOperador = _context.Pessoas.Find(idOperador);
                lista = lista.Where(c => c.Operador == pessoaOperador).ToList();
            }

            return lista;
        }

        public List<Emprestimo> ListarEmprestimosComEquipamento() => _context.Emprestimos.Include(x => x.Equipamentos)
                                        .Include(x => x.Usuario).Include(x => x.Operador)
                                       .Where(x => !x.StatusEmprestimo).ToList();


        public void Remover(int? id)
        {
            _context.Emprestimos.Remove(BuscarPorId(id));
        }

        public void Alterar(Emprestimo emp)
        {
            _context.Emprestimos.Update(emp);
            _context.SaveChanges();
        }

    }
}
