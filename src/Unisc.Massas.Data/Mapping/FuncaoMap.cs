using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class FuncaoMap : EntityTypeConfiguration<Funcao>
    {
        public FuncaoMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(45);

            // Table & Column Mappings
            ToTable("funcao", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Titulo).HasColumnName("Titulo");
        }
    }
}
