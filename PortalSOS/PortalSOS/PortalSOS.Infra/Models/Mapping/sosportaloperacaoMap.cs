using PortalSOS.Dommain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalSOS.Infra.Models.Mappingg
{
    public class sosportaloperacaoMap : EntityTypeConfiguration<sosportaloperacao_Dommain>
    {
        public sosportaloperacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdOperacao);

            // Properties
            this.Property(t => t.Operacao)
                .HasMaxLength(100);

            this.Property(t => t.Tipo)
                .HasMaxLength(70);

            this.Property(t => t.Categ)
                .HasMaxLength(70);

            this.Property(t => t.Valor)
                .HasMaxLength(100);

            this.Property(t => t.Ref)
                .HasMaxLength(100);

            this.Property(t => t.Ident)
                .HasMaxLength(1000);

            this.Property(t => t.Alteracao)
                .HasMaxLength(3000);

            this.Property(t => t.Caixa)
                .HasMaxLength(1000);

            this.Property(t => t.Turno)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("sosportaloperacao");
            this.Property(t => t.IdOperacao).HasColumnName("IdOperacao");
            this.Property(t => t.IdTipoOperacao).HasColumnName("IdTipoOperacao");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Operacao).HasColumnName("Operacao");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Categ).HasColumnName("Categ");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.Ref).HasColumnName("Ref");
            this.Property(t => t.Ident).HasColumnName("Ident");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Alteracao).HasColumnName("Alteracao");
            this.Property(t => t.Caixa).HasColumnName("Caixa");
            this.Property(t => t.Turno).HasColumnName("Turno");

            // Relationships
            this.HasRequired(t => t.sosportaltipooperacao)
                .WithMany(t => t.sosportaloperacaos)
                .HasForeignKey(d => d.IdTipoOperacao);

        }
    }
}
