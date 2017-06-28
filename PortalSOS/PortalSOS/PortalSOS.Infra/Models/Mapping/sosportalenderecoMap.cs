using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PortalSOS.Dommain;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalenderecoMap : EntityTypeConfiguration<sosportalendereco_Dommain>
    {
        public sosportalenderecoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdEndereco);

            // Properties
            this.Property(t => t.UF)
                .HasMaxLength(20);

            this.Property(t => t.Bairro)
                .HasMaxLength(100);

            this.Property(t => t.Estado)
                .HasMaxLength(100);

            this.Property(t => t.Cidade)
                .HasMaxLength(100);

            this.Property(t => t.Endereco)
                .HasMaxLength(200);

            this.Property(t => t.Complemento)
                .HasMaxLength(100);

            this.Property(t => t.Numero)
                .HasMaxLength(100);
            
            this.Property(t => t.CodMunicipio)
                 .HasMaxLength(100);

            this.Property(t => t.CEP)
                .HasMaxLength(30);

            this.Property(t => t.Municipio)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("sosportalendereco");
            this.Property(t => t.IdEndereco).HasColumnName("IdEndereco");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");
            this.Property(t => t.UF).HasColumnName("UF");
            this.Property(t => t.Bairro).HasColumnName("Bairro");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.Cidade).HasColumnName("Cidade");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Complemento).HasColumnName("Complemento");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.CodMunicipio).HasColumnName("CodMunicipio");
            this.Property(t => t.IdUf).HasColumnName("IdUf");
            this.Property(t => t.CEP).HasColumnName("CEP");
            this.Property(t => t.Municipio).HasColumnName("Municipio");
            this.Property(t => t.DescricaoTipoEndereco).HasColumnName("DescricaoTipoEndereco");
            this.Property(t => t.TipoEndereco).HasColumnName("TipoEndereco");

            // Relationships
            this.HasRequired(t => t.sosportalcliente)
                .WithMany(t => t.sosportalenderecoes)
                .HasForeignKey(d => d.IdCliente);
            this.HasRequired(t => t.sosportaluf)
                .WithMany(t => t.sosportalenderecoes)
                .HasForeignKey(d => d.IdUf);


            //// Primary Key
            //this.HasKey(t => t.IdEndereco);

            //// Properties
            //this.Property(t => t.UF)
            //    .HasMaxLength(20);

            //this.Property(t => t.Bairro)
            //    .HasMaxLength(100);

            //this.Property(t => t.Estado)
            //    .HasMaxLength(100);

            //this.Property(t => t.Cidade)
            //    .HasMaxLength(100);

            //this.Property(t => t.Endereco)
            //    .HasMaxLength(200);

            //this.Property(t => t.Complemento)
            //    .HasMaxLength(100);

            //this.Property(t => t.Numero)
            //    .HasMaxLength(100);

            //this.Property(t => t.CodMunicipio)
            //    .HasMaxLength(100);

            //this.Property(t => t.CEP)
            //    .HasMaxLength(30);

            //this.Property(t => t.Municipio)
            //    .HasMaxLength(100);

            //// Table & Column Mappings
            //this.ToTable("sosportalendereco");
            //this.Property(t => t.IdEndereco).HasColumnName("IdEndereco");
            //this.Property(t => t.UF).HasColumnName("UF");
            //this.Property(t => t.Bairro).HasColumnName("Bairro");
            //this.Property(t => t.Estado).HasColumnName("Estado");
            //this.Property(t => t.Cidade).HasColumnName("Cidade");
            //this.Property(t => t.Endereco).HasColumnName("Endereco");
            //this.Property(t => t.Complemento).HasColumnName("Complemento");
            //this.Property(t => t.Numero).HasColumnName("Numero");
            //this.Property(t => t.CodMunicipio).HasColumnName("CodMunicipio");
            //this.Property(t => t.IdUf).HasColumnName("IdUf");
            //this.Property(t => t.CEP).HasColumnName("CEP");
            //this.Property(t => t.Municipio).HasColumnName("Municipio");

            //// Relationships
            //this.HasRequired(t => t.sosportaluf)
            //    .WithMany(t => t.sosportalenderecoes)
            //    .HasForeignKey(d => d.IdUf);

        }
    }
}
