using PortalSOS.Dommain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalcontasareceberMap : EntityTypeConfiguration<sosportalcontasareceber_Dommain>
    {
        public sosportalcontasareceberMap()
        {
            // Primary Key
            this.HasKey(t => t.IdContasAReceber);

            // Properties
            this.Property(t => t.Cliente)
                .HasMaxLength(100);

            this.Property(t => t.Nota)
                .HasMaxLength(100);

            this.Property(t => t.Faturado)
                .HasMaxLength(100);

            this.Property(t => t.Parcela)
                .HasMaxLength(100);

            this.Property(t => t.Pedido)
                .HasMaxLength(100);

            this.Property(t => t.FrmPgt)
                .HasMaxLength(100);

            this.Property(t => t.Ndoc)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("sosportalcontasareceber");
            this.Property(t => t.IdContasAReceber).HasColumnName("IdContasAReceber");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Cliente).HasColumnName("Cliente");
            this.Property(t => t.Nota).HasColumnName("Nota");
            this.Property(t => t.Faturado).HasColumnName("Faturado");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.Vencimento).HasColumnName("Vencimento");
            this.Property(t => t.Parcela).HasColumnName("Parcela");
            this.Property(t => t.Pedido).HasColumnName("Pedido");
            this.Property(t => t.FrmPgt).HasColumnName("FrmPgt");
            this.Property(t => t.Ndoc).HasColumnName("Ndoc");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.StatusPed).HasColumnName("StatusPed");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");

            // Relationships
            this.HasRequired(t => t.sosportalcliente);
                //.WithMany(t => t.sosportalcontasarecebers)
                //.HasForeignKey(d => d.IdCliente);
        }
    }
}
