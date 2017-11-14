using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class UnidadeMedidaMap : EntityTypeConfiguration<UnidadeMedida>
    {
        public UnidadeMedidaMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Sigla)
                .IsRequired()
                .HasMaxLength(6);

            // Table & Column Mappings
            ToTable("unidade_medida", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Sigla).HasColumnName("Sigla");
        }
    }
}
