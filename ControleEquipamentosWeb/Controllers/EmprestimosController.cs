using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleEquipamentosWeb.Models;
using ControleEquipamentosWeb.DAL;
using ControleEquipamentosWeb.Utils;
using ControleEquipamentosWeb.ViewModels;

namespace ControleEquipamentosWeb.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly EmprestimoDAO _emprestimoDAO;
        private readonly PessoaDAO _pessoaDAO;
        private readonly EquipamentoDAO _equipamentoDAO;
        private readonly UtilsSession _utilsSession;

        private List<Equipamento> list = new List<Equipamento>();

        public EmprestimosController(EmprestimoDAO emprestimoDAO, PessoaDAO pessoaDAO, EquipamentoDAO equipamentoDAO, UtilsSession utilsSession)
        {
            _emprestimoDAO = emprestimoDAO;
            _pessoaDAO = pessoaDAO;
            _equipamentoDAO = equipamentoDAO;
            _utilsSession = utilsSession;
        }

        public IActionResult Index()
        {
            return View(_emprestimoDAO.ListarTodos());
        }

        public IActionResult Details(int? id)
        {
            var obj = _emprestimoDAO.BuscarPorId(id.Value);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EmprestimoViewModel modelo = new EmprestimoViewModel();
            modelo.DataEmprestimo = DateTime.Now;
            modelo.EquipamentosEscolhidos = new List<ItemEmprestimoViewModel>();
            var equipamentos = _equipamentoDAO.ListarTodos();
            foreach (var item in equipamentos)
            {
                ItemEmprestimoViewModel itemEmprestimo = new ItemEmprestimoViewModel
                {
                    Descricao = item.Descricao,
                    EquipamentoId = item.Id,
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    Selecionado = false
                };
                modelo.EquipamentosEscolhidos.Add(itemEmprestimo);
            }
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmprestimoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                Emprestimo emp = new Emprestimo();
                emp.Equipamentos = new List<ItemEmprestimo>();
                emp.DataEmprestimo = modelo.DataEmprestimo;
                emp.DataPrevistaDevolucao = modelo.DataPrevistaDevolucao;
                foreach (var item in modelo.EquipamentosEscolhidos)
                {
                    if (item.Selecionado)
                    {
                        ItemEmprestimo ie = new ItemEmprestimo
                        {
                            Descricao = item.Descricao,
                            EquipamentoId = item.EquipamentoId,
                            Marca = item.Marca,
                            Modelo = item.Modelo
                        };
                        emp.Equipamentos.Add(ie);
                    }
                }
                if (_emprestimoDAO.Cadastrar(emp))
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", "Não foi possível salvar o empréstimo!");
                return View(modelo);
            }
            return View(modelo);
        }

        public IActionResult Edit(int? id)
        {
            return View(_emprestimoDAO.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Emprestimo emp)
        {
            _emprestimoDAO.Alterar(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _emprestimoDAO.BuscarPorId(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _emprestimoDAO.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
