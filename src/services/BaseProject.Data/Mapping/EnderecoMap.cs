using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("numeric(18,0)")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.Numero)
                .HasColumnName("Numero")
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.Complemento)
                .HasColumnName("Complemento")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.Cep)
                .HasColumnName("Cep")
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar(60)");

            builder.Property(p => p.Uf)
                .HasColumnName("UF")
                .HasColumnType("varchar(2)");
        }
    }
}
