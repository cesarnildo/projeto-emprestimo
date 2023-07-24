using Emprestimo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Infra.Data.Context
{
    public class EmprestimoDbContext : DbContext
    {
        public EmprestimoDbContext(DbContextOptions<EmprestimoDbContext> options) : base(options)
        {
            
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Emprestimos> Emprestimos { get; set; }
        public DbSet<Jogos> jogos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmprestimoDbContext).Assembly);
        }

    }
}
