using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEquipamentosWeb.DAL;
using ControleEquipamentosWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEquipamentosWeb.Controllers
{
    [Route("api/Equip")]
    [ApiController]
    public class EquipamentosAPIController : ControllerBase
    {
        private readonly EquipamentoDAO _equipamentoDAO;

        public EquipamentosAPIController(EquipamentoDAO equipamentoDAO)
        {
            _equipamentoDAO = equipamentoDAO;
        }

        //GET: /api/Equipamentos/ListarTodos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_equipamentoDAO.ListarTodos());
        }

        //GET: /api/Equipamentos/ListarEquipamentosDisponiveis
        [HttpGet]
        [Route("ListarEquipamentosDisponiveis")]
        public IActionResult ListarEquipamentosDisponiveis()
        {
            return Ok(_equipamentoDAO.ListarDisponiveis());
        }

        //GET: /api/Equipamentos/Cadastrar
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Create([FromBody]Equipamento eq)
        {
            if (ModelState.IsValid)
            {
                if (_equipamentoDAO.Cadastrar(eq))
                {
                    return Created("", eq);
                }
            }
            return BadRequest(ModelState);
        }
    }
}