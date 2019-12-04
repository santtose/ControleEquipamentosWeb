using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleEquipamentosWeb.Models;
using ControleEquipamentosWeb.DAL;
using Microsoft.AspNetCore.Identity;

namespace ControleEquipamentosWeb.Controllers
{
    public class PessoasController : Controller
    {
        private readonly PessoaDAO _pessoaDAO;
        private readonly UserManager<UsuarioLogado> _userManager;
        private readonly SignInManager<UsuarioLogado> _signManager;

        public PessoasController(PessoaDAO pessoaDAO, UserManager<UsuarioLogado> userManager, SignInManager<UsuarioLogado> signManager)
        {
            _pessoaDAO = pessoaDAO;
            _userManager = userManager;
            _signManager = signManager;
        }

        // GET: Pessoas
        public IActionResult Index()
        {
            return View(_pessoaDAO.ListarTodos());
        }

        // GET: Pessoas/Details/5
        public IActionResult Details(int? id)
        {
            var obj = _pessoaDAO.BuscarPorId(id.Value);
            return View(obj);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            Pessoa modelo = new Pessoa();
            modelo.Aniversario = DateTime.Now;
            return View(modelo);
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pessoa p)
        {
            if (ModelState.IsValid)
            {
                //Criar um objeto do UsuarioLogado e passar                 
                //obrigatoriamente o Email e UserName
                UsuarioLogado usuarioLogado = new UsuarioLogado
                {
                    Email = p.Email,
                    UserName = p.Email
                };

                //Cadastra o usuário na tabela do Identity
                IdentityResult result = await _userManager.CreateAsync(usuarioLogado, p.Senha);

                if (result.Succeeded)
                {
                    await _signManager.SignInAsync(usuarioLogado, isPersistent: false);

                    if (_pessoaDAO.Cadastrar(p))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError
                        ("", "Pessoa já existe!");
                    return View(p);
                }
            }
            return View(p);
        }

        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Pessoa p)
        {
            var resultado = await _signManager.PasswordSignInAsync(p.Email, p.Senha, true, lockoutOnFailure: false);
            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Falha no login");
            return View();
        }

        // GET: Pessoas/Edit/5
        public IActionResult Edit(int? id)
        {
            return View(_pessoaDAO.BuscarPorId(id));
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pessoa p)
        {
            _pessoaDAO.Alterar(p);
            return RedirectToAction("Index");
        }

        // GET: Pessoas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _pessoaDAO.BuscarPorId(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _pessoaDAO.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
