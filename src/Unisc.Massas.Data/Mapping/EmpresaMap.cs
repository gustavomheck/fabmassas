using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Cnpj)
                .IsRequired()
                .HasMaxLength(14);

            Property(t => t.InscEstadual)
                .HasMaxLength(14);

            Property(t => t.InscMunicipal)
                .HasMaxLength(12);

            Property(t => t.RazaoSocial)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.Apelido)
                .HasMaxLength(60);

            Property(t => t.Logomarca)
                .HasMaxLength(255);

            Property(t => t.Bairro)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.Logradouro)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Site)
                .HasMaxLength(255);

            Property(t => t.Email)
                .HasMaxLength(45);

            // Table & Column Mappings
            ToTable("empresa", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Cnpj).HasColumnName("Cnpj");
            Property(t => t.InscEstadual).HasColumnName("InscEstadual");
            Property(t => t.InscMunicipal).HasColumnName("InscMunicipal");
            Property(t => t.RazaoSocial).HasColumnName("RazaoSocial");
            Property(t => t.Apelido).HasColumnName("Apelido");
            Property(t => t.Logomarca).HasColumnName("Logomarca");
            Property(t => t.Cep).HasColumnName("Cep");
            Property(t => t.Bairro).HasColumnName("Bairro");
            Property(t => t.Logradouro).HasColumnName("Logradouro");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.Site).HasColumnName("Site");
            Property(t => t.Email).HasColumnName("Email");
        }
    }
}
