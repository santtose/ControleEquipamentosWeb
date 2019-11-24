using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleEquipamentosWeb.Models;
using ControleEquipamentosWeb.DAL;

namespace ControleEquipamentosWeb.Controllers
{
    public class EquipamentosController : Controller
    {
        private readonly EquipamentoDAO _equipamentoDAO;

        public EquipamentosController(EquipamentoDAO equipamentoDAO)
        {
            _equipamentoDAO = equipamentoDAO;
        }

        public IActionResult Index()
        {
            return View(_equipamentoDAO.ListarTodos());
        }

        public IActionResult Details(int? id)
        {
            var obj = _equipamentoDAO.BuscarPorId(id.Value);
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Equipamento eq)
        {
            if (ModelState.IsValid)
            {
                if (_equipamentoDAO.Cadastrar(eq))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError
                    ("", "Equipamento já existe!");
                return View(eq);
            }
            return View(eq);
        }

        public IActionResult Edit(int? id)
        {
            return View(_equipamentoDAO.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Equipamento eq)
        {
            _equipamentoDAO.Alterar(eq);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _equipamentoDAO.BuscarPorId(id.Value);
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
            _equipamentoDAO.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
