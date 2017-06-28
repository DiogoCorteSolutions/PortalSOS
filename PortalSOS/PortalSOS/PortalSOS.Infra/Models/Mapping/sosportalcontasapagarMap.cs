using PortalSOS.Dommain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalcontasapagarMap : EntityTypeConfiguration<sosportalcontasapagar_Dommain>
    {
        public sosportalcontasapagarMap()
        {
            // Primary Key
            this.HasKey(t => t.IdContasAPagar);

            // Properties
            this.Property(t => t.Fornecedor)
                .HasMaxLength(100);

            this.Property(t => t.Identificacao)
                .HasMaxLength(100);

            this.Property(t => t.Nota)
                .HasMaxLength(100);

            this.Property(t => t.Faturado)
                .HasMaxLength(100);

            this.Property(t => t.Boleto)
                .HasMaxLength(100);

            this.Property(t => t.Nf)
                .HasMaxLength(100);

            this.Property(t => t.Nfatura)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("sosportalcontasapagar");
            this.Property(t => t.IdContasAPagar).HasColumnName("IdContasAPagar");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Fornecedor).HasColumnName("Fornecedor");
            this.Property(t => t.Identificacao).HasColumnName("Identificacao");
            this.Property(t => t.Nota).HasColumnName("Nota");
            this.Property(t => t.Faturado).HasColumnName("Faturado");
            this.Property(t => t.Boleto).HasColumnName("Boleto");
            this.Property(t => t.Vencimento).HasColumnName("Vencimento");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.Parcela).HasColumnName("Parcela");
            this.Property(t => t.Nf).HasColumnName("Nf");
            this.Property(t => t.Nfatura).HasColumnName("Nfatura");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");

            // Relationships
            this.HasRequired(t => t.sosportalcliente);
                //.withmany(t => t.sosportalcontasapagars)
                //.HasForeignKey(d => d.IdCliente);

        }
    }
}
