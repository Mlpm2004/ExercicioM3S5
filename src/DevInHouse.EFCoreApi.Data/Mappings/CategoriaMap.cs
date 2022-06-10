using DevInHouse.EFCoreApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevInHouse.EFCoreApi.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            // Opcional, pois por convenção nossa propriedade já seria a chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.HasData(new List<Categoria>
            {
                new Categoria(1, "Aventura"),
                new Categoria(2, "Romance"),
                new Categoria(3, "Terror")
            });
        }
    }
}