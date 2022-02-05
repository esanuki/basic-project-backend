using BaseProject.Core.Helpers;
using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BaseProject.Data.Context
{
    public class BaseProjectContext : DbContext
    {
        public BaseProjectContext(DbContextOptions<BaseProjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseProjectContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()).Where(e => !e.GetConstraintName().Contains("FK_VendaItem_Venda_VendaId")))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Administrador",
                    Email = "admin@email.com",
                    Senha = ConvertMD5.CriptografiaMD5("12345")
                }
            );
        }
    }
}
