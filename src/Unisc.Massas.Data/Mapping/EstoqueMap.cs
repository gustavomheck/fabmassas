using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class EstoqueMap : EntityTypeConfiguration<Estoque>
    {
        public EstoqueMap()
        {
            // Primary Key
            HasKey(t => new { t.Id, t.ProdutoId });

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.ProdutoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("estoque", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ProdutoId).HasColumnName("ProdutoId");
            Property(t => t.DataEntrada).HasColumnName("DataEntrada");
            Property(t => t.DataVencimento).HasColumnName("DataVencimento");
            Property(t => t.ValorProduto).HasColumnName("ValorProduto");
            Property(t => t.ValorUnidade).HasColumnName("ValorUnidade");
            Property(t => t.QuantComprada).HasColumnName("QuantComprada");
            Property(t => t.QuantDisponivel).HasColumnName("QuantDisponivel");

            // Relationships
            HasRequired(t => t.Produto)
                .WithMany(t => t.Estoques)
                .HasForeignKey(d => d.ProdutoId);

        }
    }
}
