using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PortalSOS.Dommain;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalconfiguracaopessoaMap : EntityTypeConfiguration<sosportalconfiguracaopessoa_Dommain>
    {
        public sosportalconfiguracaopessoaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdSosPortalConfiguracaoPessoa);

            // Properties
            // Table & Column Mappings
            this.ToTable("sosportalconfiguracaopessoa");
            this.Property(t => t.IdSosPortalConfiguracaoPessoa).HasColumnName("IdSosPortalConfiguracaoPessoa");
            this.Property(t => t.IdConfiguracao).HasColumnName("IdConfiguracao");
            this.Property(t => t.IdPortalPessoa).HasColumnName("IdPortalPessoa");
            this.Property(t => t.IdPortalLoja).HasColumnName("IdPortalLoja");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.sosportalloja)
                .WithMany(t => t.sosportalconfiguracaopessoa)
                .HasForeignKey(d => d.IdPortalLoja);
            this.HasRequired(t => t.sosportalpessoa)
                .WithMany(t => t.sosportalconfiguracaopessoa)
                .HasForeignKey(d => d.IdPortalPessoa);

        }
    }
}
