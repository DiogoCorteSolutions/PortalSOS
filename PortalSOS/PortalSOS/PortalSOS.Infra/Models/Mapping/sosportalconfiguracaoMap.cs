using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalconfiguracaoMap : EntityTypeConfiguration<sosportalconfiguracao_Dommain>
    {
        public sosportalconfiguracaoMap()
        {


            // Primary Key
            this.HasKey(t => t.IdConfiguracao);

            // Properties
            this.Property(t => t.ControllerAction)
                .HasMaxLength(100);

            this.Property(t => t.ViewName);

            this.Property(t => t.DescricaoTipo);

            this.Property(t => t.IdController);

            // Table & Column Mappings
            this.ToTable("sosportalconfiguracao");
            this.Property(t => t.IdConfiguracao).HasColumnName("IdConfiguracao");
            this.Property(t => t.IdController).HasColumnName("IdController");
            this.Property(t => t.DescricaoTipo).HasColumnName("DescricaoTipo");
            this.Property(t => t.ControllerAction).HasColumnName("ControllerAction");
            //this.Property(t => t.ViewName).HasColumnName("ViewName");
            this.Property(t => t.Status).HasColumnName("Status");


            //// Primary Key
            //this.HasKey(t => t.IdConfiguracao);

            //// Properties
            //this.Property(t => t.Controller)
            //    .HasMaxLength(100);

            //this.Property(t => t.ViewName)
            //    .HasMaxLength(100);

            //// Table & Column Mappings
            //this.ToTable("sosportalconfiguracao");
            //this.Property(t => t.IdConfiguracao).HasColumnName("IdConfiguracao");
            //this.Property(t => t.Controller).HasColumnName("Controller");
            //this.Property(t => t.ViewName).HasColumnName("ViewName");
            //this.Property(t => t.IdCliente).HasColumnName("IdCliente");

        }
    }
}
