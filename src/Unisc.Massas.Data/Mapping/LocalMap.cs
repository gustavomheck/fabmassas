using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class LocalMap : EntityTypeConfiguration<Local>
    {
        public LocalMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Logradouro)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.Bairro)
                .IsRequired()
                .HasMaxLength(45);

            Property(t => t.Numero)
                .HasMaxLength(20);

            Property(t => t.Complemento)
                .HasMaxLength(60);

            // Table & Column Mappings
            ToTable("local", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ClienteId).HasColumnName("ClienteId");
            Property(t => t.Cep).HasColumnName("Cep");
            Property(t => t.Logradouro).HasColumnName("Logradouro");
            Property(t => t.Bairro).HasColumnName("Bairro");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.Complemento).HasColumnName("Complemento");

            // Relationships
            HasRequired(t => t.Cliente)
                .WithMany(t => t.Locais)
                .HasForeignKey(d => d.ClienteId)
                .WillCascadeOnDelete(true);
        }
    }
}
