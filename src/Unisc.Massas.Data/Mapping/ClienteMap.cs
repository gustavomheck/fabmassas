using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Cnpj)
                .HasMaxLength(14);

            Property(t => t.Cpf)
                .HasMaxLength(11);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.InscEstadual)
                .HasMaxLength(12);

            Property(t => t.InscMunicipal)
                .HasMaxLength(9);

            Property(t => t.Site)
                .HasMaxLength(255);

            Property(t => t.Email)
                .HasMaxLength(60);

            // Table & Column Mappings
            ToTable("cliente", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Cnpj).HasColumnName("Cnpj");
            Property(t => t.Cpf).HasColumnName("Cpf");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.InscEstadual).HasColumnName("InscEstadual");
            Property(t => t.InscMunicipal).HasColumnName("InscMunicipal");
            Property(t => t.Site).HasColumnName("Site");
            Property(t => t.Email).HasColumnName("Email");
        }
    }
}
