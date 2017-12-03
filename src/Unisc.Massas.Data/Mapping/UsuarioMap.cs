using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.LoginUsuario)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(32);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.Email)
                .HasMaxLength(60);

            // Table & Column Mappings
            ToTable("usuario", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.LoginUsuario).HasColumnName("LoginUsuario");
            Property(t => t.Senha).HasColumnName("Senha");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.IsSuperAdmin).HasColumnName("IsSuperAdmin");
            Property(t => t.DataCriacao).HasColumnName("DataCriacao");
        }
    }
}
