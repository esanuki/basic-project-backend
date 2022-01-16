using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BaseProject.Data.Mapping
{
    public class VendaItemMap : IEntityTypeConfiguration<VendaItem>
    {
        public void Configure(EntityTypeBuilder<VendaItem> builder)
        {
            builder.ToTable("VendaItem", "dbo");

            builder.HasKey(vi => vi.Id);
            builder.Property(vi => vi.Id)
                .HasColumnType("numeric(18,0)")
                .ValueGeneratedOnAdd();

            builder.Property(vi => vi.Qtde)
                .HasColumnType("int")
                .HasColumnName("Quantidade");

            builder.Property(vi => vi.ValorUnitario)
                .HasColumnType("numeric(18,0)")
                .HasColumnName("ValorUnitario");

            builder.Property(vi => vi.Desconto)
                .HasColumnType("numeric(18,0)")
                .HasColumnName("ValorUnitario");

            builder.Property(vi => vi.VendaId)
                .HasColumnType("numeric(18,0)")
                .HasColumnName("VendaId");

            builder.Property(vi => vi.ProdutoId)
                .HasColumnType("numeric(18,0)")
                .HasColumnName("ProdutoId");

            builder.HasOne(vi => vi.Produto)
                .WithMany(p => p.VendaItens)
                .HasForeignKey(vi => vi.ProdutoId);

            builder.HasOne(vi => vi.Venda)
                .WithMany(v => v.VendaItens)
                .HasForeignKey(vi => vi.VendaId);
        }
    }
}
