using PortalSOS.Dommain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalpessoaMap : EntityTypeConfiguration<sosportalpessoa_Dommain>
    {
        public sosportalpessoaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPessoa);

            // Properties
            this.Property(t => t.Pessoa)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Razao)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.InscMunicipal)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Cnpj)
                .HasMaxLength(100);

            this.Property(t => t.Estadual)
                .HasMaxLength(100);

            this.Property(t => t.Endereco)
                .HasMaxLength(100);

            this.Property(t => t.N)
                .HasMaxLength(100);

            this.Property(t => t.Compl)
                .HasMaxLength(100);

            this.Property(t => t.Bairro)
                .HasMaxLength(100);

            this.Property(t => t.CodMunicipio)
                .HasMaxLength(100);

            this.Property(t => t.Municipio)
                .HasMaxLength(100);

            this.Property(t => t.Cnae)
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Cep)
                .HasMaxLength(100);

            this.Property(t => t.Uf)
                .HasMaxLength(100);

            this.Property(t => t.Telefone)
                .HasMaxLength(100);

            this.Property(t => t.TipodeTel)
                .HasMaxLength(100);

            this.Property(t => t.TipoEnd)
                .HasMaxLength(100);

            this.Property(t => t.Operadora)
                .HasMaxLength(100);

            this.Property(t => t.Contato)
                .HasMaxLength(100);

            this.Property(t => t.CodVenda)
                .HasMaxLength(100);

            this.Property(t => t.Licenca)
                .HasMaxLength(100);

            this.Property(t => t.Ativacao)
                .HasMaxLength(100);

            this.Property(t => t.Total)
                .HasMaxLength(100);

            this.Property(t => t.Obs)
                .HasMaxLength(100);

            this.Property(t => t.LimiteCred)
                .HasMaxLength(100);

            this.Property(t => t.Emitente)
                .HasMaxLength(100);

            this.Property(t => t.Modelo)
                .HasMaxLength(100);

            this.Property(t => t.Serie)
                .HasMaxLength(100);

            this.Property(t => t.Classificacao)
                .HasMaxLength(100);

            this.Property(t => t.CPF)
                .HasMaxLength(100);

            this.Property(t => t.Tipo)
                .HasMaxLength(100);

            this.Property(t => t.Representante)
                .HasMaxLength(100);

            this.Property(t => t.Ultilizado)
                .HasMaxLength(100);

            this.Property(t => t.Senha)
                .HasMaxLength(50);

            this.Property(t => t.RG)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("sosportalpessoa");
            this.Property(t => t.IdPessoa).HasColumnName("IdPessoa");
            this.Property(t => t.IdPerfil).HasColumnName("IdPerfil");
            this.Property(t => t.IdLoja).HasColumnName("IdLoja");
            this.Property(t => t.Pessoa).HasColumnName("Pessoa");
            this.Property(t => t.Razao).HasColumnName("Razao");
            this.Property(t => t.InscMunicipal).HasColumnName("InscMunicipal");
            this.Property(t => t.Cnpj).HasColumnName("Cnpj");
            this.Property(t => t.Estadual).HasColumnName("Estadual");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.N).HasColumnName("N");
            this.Property(t => t.Compl).HasColumnName("Compl");
            this.Property(t => t.Bairro).HasColumnName("Bairro");
            this.Property(t => t.CodMunicipio).HasColumnName("CodMunicipio");
            this.Property(t => t.Municipio).HasColumnName("Municipio");
            this.Property(t => t.Cnae).HasColumnName("Cnae");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Cep).HasColumnName("Cep");
            this.Property(t => t.Uf).HasColumnName("Uf");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.TipodeTel).HasColumnName("TipodeTel");
            this.Property(t => t.TipoEnd).HasColumnName("TipoEnd");
            this.Property(t => t.Operadora).HasColumnName("Operadora");
            this.Property(t => t.Contato).HasColumnName("Contato");
            this.Property(t => t.CodVenda).HasColumnName("CodVenda");
            this.Property(t => t.Licenca).HasColumnName("Licenca");
            this.Property(t => t.Ativacao).HasColumnName("Ativacao");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.Obs).HasColumnName("Obs");
            this.Property(t => t.LimiteCred).HasColumnName("LimiteCred");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Emitente).HasColumnName("Emitente");
            this.Property(t => t.Modelo).HasColumnName("Modelo");
            this.Property(t => t.Serie).HasColumnName("Serie");
            this.Property(t => t.Classificacao).HasColumnName("Classificacao");
            this.Property(t => t.CPF).HasColumnName("CPF");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Representante).HasColumnName("Representante");
            this.Property(t => t.Ultilizado).HasColumnName("Ultilizado");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.RG).HasColumnName("RG");

            // Relationships
            this.HasRequired(t => t.sosportalloja)
                .WithMany(t => t.sosportalpessoas)
                .HasForeignKey(d => d.IdLoja);
            this.HasRequired(t => t.sosportalperfil);

        }
    }
}
