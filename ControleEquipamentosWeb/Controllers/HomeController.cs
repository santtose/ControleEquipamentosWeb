using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleEquipamentosWeb.Models;
using Microsoft.AspNetCore.Identity;
using ControleEquipamentosWeb.DAL;

namespace ControleEquipamentosWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly EquipamentoDAO _equipamentoDAO;
        private readonly UserManager<UsuarioLogado> _userManager;
        private readonly SignInManager<UsuarioLogado> _signManager;

        public HomeController(EquipamentoDAO equipamentoDAO, UserManager<UsuarioLogado> userManager, SignInManager<UsuarioLogado> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _equipamentoDAO = equipamentoDAO;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login","Pessoas");
            }
            List<Equipamento> lista = _equipamentoDAO.ListarParaReparo();
            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
