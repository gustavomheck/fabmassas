using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class PermissaoFuncaoMap : EntityTypeConfiguration<PermissaoFuncao>
    {
        public PermissaoFuncaoMap()
        {
            // Primary Key
            HasKey(t => new { t.Id, t.FuncaoId, t.PermissaoId });

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.FuncaoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.PermissaoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("permissao_funcao", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.FuncaoId).HasColumnName("FuncaoId");
            Property(t => t.PermissaoId).HasColumnName("PermissaoId");

            // Relationships
            HasRequired(t => t.Funcao)
                .WithMany(t => t.PermissoesFuncao)
                .HasForeignKey(d => d.FuncaoId);
            HasRequired(t => t.Permissao)
                .WithMany(t => t.PermissoesFuncao)
                .HasForeignKey(d => d.PermissaoId);
        }
    }
}
