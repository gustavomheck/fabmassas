using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Sigla)
                .IsRequired()
                .HasMaxLength(2);

            // Table & Column Mappings
            ToTable("estado", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.PaisId).HasColumnName("PaisId");
            Property(t => t.CodIbge).HasColumnName("CodIbge");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Sigla).HasColumnName("Sigla");

            // Relationships
            HasRequired(t => t.Pais)
                .WithMany(t => t.Estados)
                .HasForeignKey(d => d.PaisId);

        }
    }
}
