using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class PaisMap : EntityTypeConfiguration<Pais>
    {
        public PaisMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(45);

            Property(t => t.Sigla)
                .IsRequired()
                .HasMaxLength(3);

            // Table & Column Mappings
            ToTable("pais", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.CodPais).HasColumnName("CodPais");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Sigla).HasColumnName("Sigla");
        }
    }
}
