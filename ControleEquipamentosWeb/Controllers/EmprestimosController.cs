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

namespace ControleEquipamentosWeb.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly EmprestimoDAO _emprestimoDAO;
        private readonly PessoaDAO _pessoaDAO;
        private readonly EquipamentoDAO _equipamentoDAO;
        private readonly ItemEmprestimoDAO _itemEmprestimoDAO;
        private readonly UtilsSession _utilsSession;

        private List<Equipamento> list = new List<Equipamento>();

        public EmprestimosController(EmprestimoDAO emprestimoDAO, PessoaDAO pessoaDAO, EquipamentoDAO equipamentoDAO, UtilsSession utilsSession, ItemEmprestimoDAO itemEmprestimoDAO)
        {
            _emprestimoDAO = emprestimoDAO;
            _pessoaDAO = pessoaDAO;
            _equipamentoDAO = equipamentoDAO;
            _utilsSession = utilsSession;
            _itemEmprestimoDAO = itemEmprestimoDAO;
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
            ViewBag.Equipamentos = new SelectList(_equipamentoDAO.ListarTodos(), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Emprestimo emp, int drpEquipamentos)
        {

            ViewBag.Equipamentos = new SelectList(_equipamentoDAO.ListarTodos(), "Id", "Descricao");
            emp.Equipamento = _equipamentoDAO.BuscarPorId(drpEquipamentos);

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

        public IActionResult AdicionarNaCesta(int id)
        {
            Emprestimo p = _emprestimoDAO.BuscarPorId(id);

            ItemEmprestimo i = new ItemEmprestimo
            {
                Emprestimo = p,
                Quantidade = 1,
                CestaId = _utilsSession.RetornarCestaId()
            };
            _itemEmprestimoDAO.Cadastrar(i);
            return RedirectToAction("CestaEquipamentos");
        }

        public IActionResult CestaEquipamentos()
        {
            return View(_itemEmprestimoDAO.ListarItensPorCestaId(_utilsSession.RetornarCestaId()));
        }

    }
}
