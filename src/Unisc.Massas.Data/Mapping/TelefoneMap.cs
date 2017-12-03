using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Observacao)
                .HasMaxLength(256);

            // Table & Column Mappings
            ToTable("telefone", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.ClienteId).HasColumnName("ClienteId");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.Observacao).HasColumnName("Observacao");

            // Relationships
            HasOptional(t => t.Cliente)
                .WithMany(t => t.Telefones)
                .HasForeignKey(d => d.ClienteId);
            HasOptional(t => t.Empresa)
                .WithMany(t => t.Telefones)
                .HasForeignKey(d => d.EmpresaId);
        }
    }
}
