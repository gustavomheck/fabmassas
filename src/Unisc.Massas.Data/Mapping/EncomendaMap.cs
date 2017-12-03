using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class EncomendaMap : EntityTypeConfiguration<Encomenda>
    {
        public EncomendaMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            ToTable("encomenda", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ClienteId).HasColumnName("ClienteId");
            Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            Property(t => t.LocalId).HasColumnName("LocalId");
            Property(t => t.DataPedido).HasColumnName("DataPedido");
            Property(t => t.DataEntrega).HasColumnName("DataEntrega");
            Property(t => t.Peso).HasColumnName("Peso");
            Property(t => t.Valor).HasColumnName("Valor");
            Property(t => t.QuantPacotes).HasColumnName("QuantPacotes");
            Property(t => t.Status).HasColumnName("Status");

            HasRequired(t => t.Cliente)
                .WithMany(t => t.Encomendas)
                .HasForeignKey(d => d.ClienteId);
            HasRequired(t => t.Empresa)
                .WithMany(t => t.Encomendas)
                .HasForeignKey(d => d.EmpresaId);
            HasRequired(t => t.Local)
                .WithMany(t => t.Encomendas)
                .HasForeignKey(d => d.LocalId);
        }
    }
}
