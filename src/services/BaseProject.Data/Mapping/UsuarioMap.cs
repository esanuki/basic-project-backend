using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("numeric(18,0)")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(45)");

            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.Property(p => p.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(60)");
        }
    }
}
