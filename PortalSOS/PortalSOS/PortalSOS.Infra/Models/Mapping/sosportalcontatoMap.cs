using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PortalSOS.Dommain;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalcontatoMap : EntityTypeConfiguration<sosportalcontato_Dommain>
    {
        public sosportalcontatoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdContato);

            // Properties
            this.Property(t => t.Telefone)
                .HasMaxLength(100);

            this.Property(t => t.TipoTel)
                .HasMaxLength(20);

            this.Property(t => t.Operadora)
                .HasMaxLength(100);

            this.Property(t => t.Celular)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("sosportalcontato");
            this.Property(t => t.IdContato).HasColumnName("IdContato");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.TipoTel).HasColumnName("TipoTel");
            this.Property(t => t.Operadora).HasColumnName("Operadora");
            this.Property(t => t.Celular).HasColumnName("Celular");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");

            // Relationships
            this.HasOptional(t => t.sosportalcliente)
                .WithMany(t => t.sosportalcontatoes)
                .HasForeignKey(d => d.IdCliente);
        }
    }
}
