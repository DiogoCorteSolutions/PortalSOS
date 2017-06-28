using PortalSOS.Dommain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportallojaMap : EntityTypeConfiguration<sosportalloja_Dommain>
    {
        public sosportallojaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdLoja);

            // Properties
            this.Property(t => t.Cnpj)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NomeFantasia)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Telefone)
                .HasMaxLength(30);

            this.Property(t => t.Endereco)
                .HasMaxLength(100);

            this.Property(t => t.Complemento)
                .HasMaxLength(100);

            this.Property(t => t.Numero)
                .HasMaxLength(50);

            this.Property(t => t.Cep)
                .HasMaxLength(50);

            this.Property(t => t.ResponsavelCadastro)
                .HasMaxLength(100);

            this.Property(t => t.Senha)
                .HasMaxLength(40);

            this.Property(t => t.PerfilLoja)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("sosportalloja");
            this.Property(t => t.IdLoja).HasColumnName("IdLoja");
            this.Property(t => t.Cnpj).HasColumnName("Cnpj");
            this.Property(t => t.NomeFantasia).HasColumnName("NomeFantasia");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Datacadastro).HasColumnName("Datacadastro");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Complemento).HasColumnName("Complemento");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Cep).HasColumnName("Cep");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.ResponsavelCadastro).HasColumnName("ResponsavelCadastro");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.PerfilLoja).HasColumnName("PerfilLoja");
        }
    }
}
