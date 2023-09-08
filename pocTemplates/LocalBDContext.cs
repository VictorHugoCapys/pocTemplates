using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pocTemplates
{
    public class LocalBDContext : DbContext
    {
        public DbSet<VariaveisTemplates> VariaveisTemplate { get; set; }
        public DbSet<TabelaDeDado> TabelaDeDados { get; set; }
        public DbSet<TabelaDeDado2> TabelaDeDados2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}/BancoLocal.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabelaDeDado2>()
                .HasOne(t2 => t2.TabelaDeDado)  
                .WithMany()                    
                .HasForeignKey(t2 => t2.idDados); 
        }

        public class VariaveisTemplates
        {
            public int ID { get; set; }
            public string identificador { get; set; }
            public string operacao { get; set; }
            public string modulo { get; set; }
            public string nome { get; set; }
        }

        public class TabelaDeDado
        {
            public int ID { get; set; }
            public string nome { get; set; }
            public int idade { get; set; }
            public decimal altura { get; set; }
        }

        public class TabelaDeDado2
        {
            public int ID { get; set; }
            public string telefone { get; set; }
            public int idDados { get; set; }
            public TabelaDeDado TabelaDeDado { get; set; }
        }
    }
}
