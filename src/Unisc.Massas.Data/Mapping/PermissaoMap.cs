using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class PermissaoMap : EntityTypeConfiguration<Permissao>
    {
        public PermissaoMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.TituloPermissao)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.NomePermissao)
                .IsRequired()
                .HasMaxLength(45);

            // Table & Column Mappings
            ToTable("permissao", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.TituloPermissao).HasColumnName("TituloPermissao");
            Property(t => t.NomePermissao).HasColumnName("NomePermissao");
        }
    }
}
