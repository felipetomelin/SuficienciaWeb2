using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuficienciaWebII.Entities;

namespace SuficienciaWebII.Database.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");
            builder.HasKey(x => new { x.Id, x.IdComanda });

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").IsRequired();
            builder.Property(x => x.IdComanda).HasColumnName("id_comanda").IsRequired();
        }
    }
}