using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(45);

            Property(t => t.Populacao)
                .HasMaxLength(45);

            Property(t => t.Gentilico)
                .HasMaxLength(250);

            // Table & Column Mappings
            ToTable("cidade", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.EstadoId).HasColumnName("EstadoId");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.CodIbge).HasColumnName("CodIbge");
            Property(t => t.DensidadeDemo).HasColumnName("DensidadeDemo");
            Property(t => t.Populacao).HasColumnName("Populacao");
            Property(t => t.Gentilico).HasColumnName("Gentilico");
            Property(t => t.Area).HasColumnName("Area");

            // Relationships
            HasRequired(t => t.Estado)
                .WithMany(t => t.Cidades)
                .HasForeignKey(d => d.EstadoId);
        }
    }
}
