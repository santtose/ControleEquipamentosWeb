using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Models
{
    public class Context : IdentityDbContext<UsuarioLogado>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<ItemEmprestimo> ItemEmprestimos { get; set; }
    }
}
