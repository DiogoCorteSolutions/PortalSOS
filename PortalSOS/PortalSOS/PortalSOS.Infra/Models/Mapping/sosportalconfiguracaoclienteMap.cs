using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PortalSOS.Dommain;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalconfiguracaoclienteMap : EntityTypeConfiguration<sosportalconfiguracaocliente_Dommain>
    {
        public sosportalconfiguracaoclienteMap()
        {
            // Primary Key
            this.HasKey(t => t.IdConfiguracaoCliente);

            // Properties
            // Table & Column Mappings
            this.ToTable("sosportalconfiguracaocliente");
            this.Property(t => t.IdConfiguracaoCliente).HasColumnName("IdConfiguracaoCliente");
            this.Property(t => t.IdConfiguracao).HasColumnName("IdConfiguracao");
            this.Property(t => t.IdPerfil).HasColumnName("IdPerfil");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");
            this.Property(t => t.IdPessoaLoja).HasColumnName("IdPessoaLoja");
            this.Property(t => t.TipoPessoa).HasColumnName("TipoPessoa");
            this.Property(t => t.TipoPerfil).HasColumnName("TipoPerfil");

            // Relationships
            this.HasRequired(t => t.sosportalcliente)
                .WithMany(t => t.sosportalconfiguracaoclientes)
                .HasForeignKey(d => d.IdCliente);
            this.HasRequired(t => t.sosportalconfiguracao)
                .WithMany(t => t.sosportalconfiguracaoclientes)
                .HasForeignKey(d => d.IdConfiguracao);
            this.HasRequired(t => t.sosportalperfil)
                .WithMany(t => t.sosportalconfiguracaoclientes)
                .HasForeignKey(d => d.IdPerfil);


            //// Primary Key
            //this.HasKey(t => t.IdConfiguracaoCliente);

            //// Properties
            //// Table & Column Mappings
            //this.ToTable("sosportalconfiguracaocliente");
            //this.Property(t => t.IdConfiguracaoCliente).HasColumnName("IdConfiguracaoCliente");
            //this.Property(t => t.IdConfiguracao).HasColumnName("IdConfiguracao");
            //this.Property(t => t.IdPerfil).HasColumnName("IdPerfil");
            //this.Property(t => t.Status).HasColumnName("Status");

            //// Relationships
            //this.HasRequired(t => t.sosportalconfiguracao)
            //    .WithMany(t => t.sosportalconfiguracaoclientes)
            //    .HasForeignKey(d => d.IdConfiguracao);
        }
    }
}
