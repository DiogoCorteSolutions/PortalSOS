using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PortalSOS.Dommain;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalclienteMap : EntityTypeConfiguration<sosportalcliente_Dommain>
    {
        public sosportalclienteMap()
        {

            // Primary Key
            this.HasKey(t => t.IdCliente);

            // Properties
            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Pessoa)
                .HasMaxLength(200);

            this.Property(t => t.Cnpj)
                .HasMaxLength(30);

            this.Property(t => t.RazaoSocial)
                .HasMaxLength(400);

            this.Property(t => t.InscricaoMunicipal)
                .HasMaxLength(400);

            this.Property(t => t.Estadual)
                .HasMaxLength(200);

            this.Property(t => t.Cnae)
                .HasMaxLength(100);

            this.Property(t => t.Licenca)
                .HasMaxLength(200);

            this.Property(t => t.Ativacao)
                 .HasMaxLength(100);

            this.Property(t => t.Obs)
                .HasMaxLength(5000);


            this.Property(t => t.Rua)
                .HasMaxLength(200);

            this.Property(t => t.Logradouro)
                .HasMaxLength(200);

            this.Property(t => t.Emitente)
                .HasMaxLength(400);

            this.Property(t => t.Modelo)
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
                .HasMaxLength(100);

            this.Property(t => t.RG)
                .HasMaxLength(30);

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

            this.Property(t => t.Telefone)
                .HasMaxLength(100);

            this.Property(t => t.TipoTel)
                .HasMaxLength(20);

            this.Property(t => t.Operadora)
                .HasMaxLength(100);

            this.Property(t => t.Celular)
                .HasMaxLength(100);

            this.Property(t => t.Segmento)
            .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("sosportalcliente");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");
            this.Property(t => t.IdPerfil).HasColumnName("IdPerfil");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Pessoa).HasColumnName("Pessoa");
            this.Property(t => t.Cnpj).HasColumnName("Cnpj");
            this.Property(t => t.RazaoSocial).HasColumnName("RazaoSocial");
            this.Property(t => t.InscricaoMunicipal).HasColumnName("InscricaoMunicipal");
            this.Property(t => t.Estadual).HasColumnName("Estadual");
            this.Property(t => t.Cnae).HasColumnName("Cnae");
            this.Property(t => t.CodProduto).HasColumnName("CodProduto");
            this.Property(t => t.Licenca).HasColumnName("Licenca");
            this.Property(t => t.Ativacao).HasColumnName("Ativacao");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.Obs).HasColumnName("Obs");
            this.Property(t => t.Rua).HasColumnName("Rua");
            this.Property(t => t.Logradouro).HasColumnName("Logradouro");
            this.Property(t => t.LimiteCred).HasColumnName("LimiteCred");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Emitente).HasColumnName("Emitente");
            this.Property(t => t.Modelo).HasColumnName("Modelo");
            this.Property(t => t.CPF).HasColumnName("CPF");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Representante).HasColumnName("Representante");
            this.Property(t => t.Ultilizado).HasColumnName("Ultilizado");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.RG).HasColumnName("RG");
            this.Property(t => t.IdPessoaLoja).HasColumnName("IdPessoaLoja");
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
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.TipoTel).HasColumnName("TipoTel");
            this.Property(t => t.Operadora).HasColumnName("Operadora");
            this.Property(t => t.Celular).HasColumnName("Celular");
            this.Property(t => t.DescricaoTipoEndereco).HasColumnName("DescricaoTipoEndereco");
            this.Property(t => t.TipoEndereco).HasColumnName("TipoEndereco");
            this.Property(t => t.Segmento).HasColumnName("Segmento");


            // Relationships
            this.HasRequired(t => t.sosportalperfil)
                .WithMany(t => t.sosportalclientes)
                .HasForeignKey(d => d.IdPerfil);
            this.HasRequired(t => t.sosportaluf)
                .WithMany(t => t.sosportalclientes)
                .HasForeignKey(d => d.IdUf);

            //// Primary Key
            //this.HasKey(t => t.IdCliente);

            //// Properties
            //this.Property(t => t.Email)
            //    .IsRequired()
            //    .HasMaxLength(200);

            //this.Property(t => t.Pessoa)
            //    .HasMaxLength(200);

            //this.Property(t => t.Cnpj)
            //    .HasMaxLength(30);

            //this.Property(t => t.RazaoSocial)
            //    .HasMaxLength(400);

            //this.Property(t => t.InscricaoMunicipal)
            //    .HasMaxLength(400);

            //this.Property(t => t.Estadual)
            //    .HasMaxLength(200);

            //this.Property(t => t.Cnae)
            //    .HasMaxLength(100);

            //this.Property(t => t.Licenca)
            //    .HasMaxLength(200);

            //this.Property(t => t.Ativacao)
            //    .HasMaxLength(100);

            //this.Property(t => t.Obs)
            //    .HasMaxLength(5000);

            //this.Property(t => t.Emitente)
            //    .HasMaxLength(400);

            //this.Property(t => t.Modelo)
            //    .HasMaxLength(100);

            //this.Property(t => t.CPF)
            //    .HasMaxLength(100);

            //this.Property(t => t.Tipo)
            //    .HasMaxLength(100);

            //this.Property(t => t.Representante)
            //    .HasMaxLength(100);

            //this.Property(t => t.Ultilizado)
            //    .HasMaxLength(100);

            //this.Property(t => t.Senha)
            //    .HasMaxLength(100);

            //this.Property(t => t.RG)
            //    .HasMaxLength(30);

            //// Table & Column Mappings
            //this.ToTable("sosportalcliente");
            //this.Property(t => t.IdCliente).HasColumnName("IdCliente");
            //this.Property(t => t.IdPerfil).HasColumnName("IdPerfil");
            //this.Property(t => t.IdEndereco).HasColumnName("IdEndereco");
            //this.Property(t => t.IdContato).HasColumnName("IdContato");
            //this.Property(t => t.Email).HasColumnName("Email");
            //this.Property(t => t.Pessoa).HasColumnName("Pessoa");
            //this.Property(t => t.Cnpj).HasColumnName("Cnpj");
            //this.Property(t => t.RazaoSocial).HasColumnName("RazaoSocial");
            //this.Property(t => t.InscricaoMunicipal).HasColumnName("InscricaoMunicipal");
            //this.Property(t => t.Estadual).HasColumnName("Estadual");
            //this.Property(t => t.Cnae).HasColumnName("Cnae");
            //this.Property(t => t.CodProduto).HasColumnName("CodProduto");
            //this.Property(t => t.Licenca).HasColumnName("Licenca");
            //this.Property(t => t.Ativacao).HasColumnName("Ativacao");
            //this.Property(t => t.Total).HasColumnName("Total");
            //this.Property(t => t.Obs).HasColumnName("Obs");
            //this.Property(t => t.LimiteCred).HasColumnName("LimiteCred");
            //this.Property(t => t.Status).HasColumnName("Status");
            //this.Property(t => t.Emitente).HasColumnName("Emitente");
            //this.Property(t => t.Modelo).HasColumnName("Modelo");
            //this.Property(t => t.CPF).HasColumnName("CPF");
            //this.Property(t => t.Tipo).HasColumnName("Tipo");
            //this.Property(t => t.Representante).HasColumnName("Representante");
            //this.Property(t => t.Ultilizado).HasColumnName("Ultilizado");
            //this.Property(t => t.Senha).HasColumnName("Senha");
            //this.Property(t => t.RG).HasColumnName("RG");

            //// Relationships
            //this.HasRequired(t => t.sosportalcontato)
            //    .WithMany(t => t.sosportalclientes)
            //    .HasForeignKey(d => d.IdContato);
            //this.HasRequired(t => t.sosportalendereco)
            //    .WithMany(t => t.sosportalclientes)
            //    .HasForeignKey(d => d.IdEndereco);
            //this.HasRequired(t => t.sosportalperfil)
            //    .WithMany(t => t.sosportalclientes)
            //    .HasForeignKey(d => d.IdPerfil);

        }
    }
}
