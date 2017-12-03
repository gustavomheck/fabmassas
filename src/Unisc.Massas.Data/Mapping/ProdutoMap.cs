using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Codigo)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(45);
            
            // Table & Column Mappings
            ToTable("produto", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.UnidadeMedidaId).HasColumnName("UnidadeMedidaId");
            Property(t => t.Codigo).HasColumnName("Codigo");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.ValorBase).HasColumnName("ValorBase");
            Property(t => t.QtdeMinimaEstoque).HasColumnName("QtdeMinimaEstoque");
            Property(t => t.IsIngrediente).HasColumnName("IsIngrediente");

            // Relationships
            HasMany(t => t.TiposMassas)
                .WithMany(t => t.Ingredientes)
                .Map(m =>
                    {
                        m.ToTable("tipo_massa_has_produto", "massas");
                        m.MapLeftKey("ProdutoId");
                        m.MapRightKey("TipoMassaId");
                    });

            HasRequired(t => t.UnidadeMedida)
                .WithMany(t => t.Produtos)
                .HasForeignKey(d => d.UnidadeMedidaId);
        }
    }
}
