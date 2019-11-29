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

        public IActionResult Create()
        {
            EmprestimoViewModel modelo = new EmprestimoViewModel();
            //TODO: Listar Apenas os equipamentos disponiveis
            modelo.EquipamentosDisponiveis = _equipamentoDAO.ListarTodos();
            modelo.EquipamentosEscolhidos = new List<Equipamento>();
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Emprestimo emp)
        {
            if (ModelState.IsValid)
            {
                if (_emprestimoDAO.Cadastrar(emp))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError
                    ("", "Emprestimo já existe!");
                return View(emp);
            }
            return View(emp);
        }

        public IActionResult AdicionarEquipamento(EmprestimoViewModel modelo, int id)
        {
            Equipamento equipamento = _equipamentoDAO.BuscarPorId(id);
            modelo.EquipamentosDisponiveis.Remove(equipamento);
            modelo.EquipamentosEscolhidos.Add(equipamento);

            return View("Create", modelo);
        }

        public IActionResult RemoverEquipamento(EmprestimoViewModel modelo, int id)
        {
            Equipamento equipamento = _equipamentoDAO.BuscarPorId(id);
            modelo.EquipamentosDisponiveis.Add(equipamento);
            modelo.EquipamentosEscolhidos.Remove(equipamento);

            return View("Create", modelo);
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
