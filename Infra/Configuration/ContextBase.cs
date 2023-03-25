using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase( DbContextOptions options) : base( options ) 
        {
            
        
        }

        public DbSet<FinancialSystem> FinancialSystem { set; get; }
        public DbSet<UserFinancialSystem> UserFinancialSystem { set; get; }
        public DbSet<Category> Category { set; get; }
        public DbSet<Despise> Despise { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);


        }

        public string ObterStringConexao()
        {
            return "Data Source=NBQSP-FC693;Initial Catalog=FinanSystem_2023;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            //return "Data Source=NBQSP-FC693;Initial Catalog=FINANCEIRO_2023;Integrated Security=True"; // Evitar
        }


    }
}
