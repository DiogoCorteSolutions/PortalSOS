using PortalSOS.Dommain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalperfilMap : EntityTypeConfiguration<sosportalperfil_Dommain>
    {
        public sosportalperfilMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPerfil);

            // Properties
            this.Property(t => t.Perfil)
                .HasMaxLength(80);

            this.Property(t => t.DescricaoTipo)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("sosportalperfil");
            this.Property(t => t.IdPerfil).HasColumnName("IdPerfil");
            this.Property(t => t.Perfil).HasColumnName("Perfil");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.DescricaoTipo).HasColumnName("DescricaoTipo");

        }
    }
}
