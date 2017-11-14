using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class TipoMassaMap : EntityTypeConfiguration<TipoMassa>
    {
        public TipoMassaMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.NomeMassa)
                .IsRequired()
                .HasMaxLength(45);
            
            // Table & Column Mappings
            ToTable("tipo_massa", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.FormaId).HasColumnName("FormaId");
            Property(t => t.MaquinaId).HasColumnName("MaquinaId");
            Property(t => t.NomeMassa).HasColumnName("NomeMassa");
            Property(t => t.PesoBase).HasColumnName("PesoBase");
            Property(t => t.ValorBase).HasColumnName("ValorBase");

            // Relationships
            HasRequired(t => t.Forma)
                .WithMany(t => t.TiposMassas)
                .HasForeignKey(d => d.FormaId);

            HasRequired(t => t.Maquina)
                .WithMany(t => t.TiposMassas)
                .HasForeignKey(d => d.MaquinaId);
        }
    }
}
