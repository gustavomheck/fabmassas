using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class FuncaoUsuarioMap : EntityTypeConfiguration<FuncaoUsuario>
    {
        public FuncaoUsuarioMap()
        {
            // Primary Key
            HasKey(t => new { t.Id, t.UsuarioId, t.FuncaoId });

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.UsuarioId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.FuncaoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("funcao_usuario", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.UsuarioId).HasColumnName("usuarioId");
            Property(t => t.FuncaoId).HasColumnName("funcaoId");

            // Relationships
            HasRequired(t => t.Funcao)
                .WithMany(t => t.FuncoesUsuarios)
                .HasForeignKey(d => d.FuncaoId);
            HasRequired(t => t.Usuario)
                .WithMany(t => t.FuncoesUsuario)
                .HasForeignKey(d => d.UsuarioId);

        }
    }
}
