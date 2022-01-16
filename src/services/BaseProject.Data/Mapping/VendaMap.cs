using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Mapping
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda", "dbo");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .HasColumnType("numeric(18,0)")
                .ValueGeneratedOnAdd();

            builder.Property(v => v.DataVenda)
                .HasColumnType("datetime")
                .HasColumnName("DataVenda");

            builder.Property(v => v.ClienteId)
                .HasColumnType("numeric(18,0)")
                .HasColumnName("ClienteId");

            builder.HasOne(v => v.Cliente)
                 .WithMany(c => c.Vendas)
                 .HasForeignKey(v => v.ClienteId);
        }
    }
}
