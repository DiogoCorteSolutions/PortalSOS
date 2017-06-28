using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PortalSOS.Dommain;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalufMap : EntityTypeConfiguration<sosportaluf_Dommain>
    {
        public sosportalufMap()
        {
            // Primary Key
            this.HasKey(t => t.IdUf);

            // Properties
            this.Property(t => t.UF)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("sosportaluf");
            this.Property(t => t.IdUf).HasColumnName("IdUf");
            this.Property(t => t.UF).HasColumnName("UF");
        }
    }
}
