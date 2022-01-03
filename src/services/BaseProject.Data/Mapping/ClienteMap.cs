using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("numeric(18,0)")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(80)");

            builder.Property(p => p.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)");

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime2");

            builder.Property(p => p.EnderecoId)
                .HasColumnName("EnderecoId")
                .HasColumnType("numeric(18,0)");

            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Cliente>(c => c.EnderecoId);
        }
    }
}
