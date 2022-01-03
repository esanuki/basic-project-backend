using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("numeric(18,0)")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(60)")
                .HasColumnName("Descricao");

            builder.Property(p => p.ValorUnitario)
                .HasColumnType("numeric(18,0")
                .HasColumnName("ValorUnitario");

        }
    }
}
