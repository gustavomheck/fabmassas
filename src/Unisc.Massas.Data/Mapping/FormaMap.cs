using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Mapping
{
    public class FormaMap : EntityTypeConfiguration<Forma>
    {
        public FormaMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(45);

            // Table & Column Mappings
            ToTable("forma", "massas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
