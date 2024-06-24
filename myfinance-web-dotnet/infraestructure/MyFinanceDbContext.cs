using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.infraestructure
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoConta {get;set;}
        public DbSet<Transacao> Transacao {get;set;}

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            var connectstring = @"Server=DESKTOP-LNJL51K\SQLEXPRESS;Database=myfinance;Trusted_Connection=True;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectstring);
        }

    }
}