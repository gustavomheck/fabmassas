using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class PacoteMap : EntityTypeConfiguration<Pacote>
    {
        public PacoteMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            ToTable("pacote", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.EncomendaId).HasColumnName("EncomendaId");
            Property(t => t.TipoMassaId).HasColumnName("TipoMassaId");
            Property(t => t.Quantidade).HasColumnName("Quantidade");

            // Relationships
            HasRequired(t => t.Encomenda).WithMany(t => t.Pacotes).HasForeignKey(d => new { d.EncomendaId }).WillCascadeOnDelete(true);
            HasRequired(t => t.TipoMassa).WithMany(t => t.Pacotes).HasForeignKey(d => new { d.TipoMassaId }).WillCascadeOnDelete(true);
        }
    }
}
