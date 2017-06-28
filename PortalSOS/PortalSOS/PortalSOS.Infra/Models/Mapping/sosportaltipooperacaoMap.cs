using PortalSOS.Dommain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportaltipooperacaoMap : EntityTypeConfiguration<sosportaltipooperacao_Dommain>
    {
        public sosportaltipooperacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdTipoOperacao);

            // Properties
            this.Property(t => t.Cc)
                .HasMaxLength(100);

            this.Property(t => t.Tipo)
                .HasMaxLength(70);

            this.Property(t => t.Tipo2)
                .HasMaxLength(70);

            this.Property(t => t.Operacao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("sosportaltipooperacao");
            this.Property(t => t.IdTipoOperacao).HasColumnName("IdTipoOperacao");
            this.Property(t => t.Cc).HasColumnName("Cc");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Tipo2).HasColumnName("Tipo2");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Operacao).HasColumnName("Operacao");
        }
    }
}
