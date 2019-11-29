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
    public class OcorrenciasController : Controller
    {
        private readonly OcorrenciaDAO _ocorrenciaDAO;
        private readonly EquipamentoDAO _equipamentoDAO;

        public OcorrenciasController(OcorrenciaDAO ocorrenciaDAO, EquipamentoDAO equipamentoDAO)
        {
            _ocorrenciaDAO = ocorrenciaDAO;
            _equipamentoDAO = equipamentoDAO;
        }

        public IActionResult Index()
        {
            return View(_ocorrenciaDAO.ListarTodos());
        }

        public IActionResult Details(int? id)
        {
            var obj = _ocorrenciaDAO.BuscarPorId(id.Value);
            return View(obj);
        }

        public IActionResult Create()
        {
            ViewBag.Equipamentos = new SelectList(_equipamentoDAO.ListarTodos(), "Id", "NumeroRegistro");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ocorrencia o, int drpEquipamentos)
        {
            ViewBag.Equipamentos = new SelectList(_equipamentoDAO.ListarTodos(), "Id", "NumeroRegistro");
            o.Equipamento = _equipamentoDAO.BuscarPorId(drpEquipamentos);

            if (ModelState.IsValid)
            {
                if (_ocorrenciaDAO.Cadastrar(o))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError
                    ("", "Ocorrência já existe!");
                return View(o);
            }
            return View(o);
        }

        public IActionResult Edit(int? id)
        {
            return View(_ocorrenciaDAO.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ocorrencia o)
        {
            _ocorrenciaDAO.Alterar(o);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _ocorrenciaDAO.BuscarPorId(id.Value);
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
            _ocorrenciaDAO.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
