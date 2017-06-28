using PortalSOS.Dommain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalSOS.Infra.Models.Mapping
{
    public class sosportalmovimentacaoMap : EntityTypeConfiguration<sosportalmovimentacao_Dommain>
    {
        public sosportalmovimentacaoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdMovimentacao, t.IdProduto, t.IdOperacao, t.IdCliente, t.Status });

            // Properties
            this.Property(t => t.IdMovimentacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.IdProduto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdOperacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdCliente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Barras)
                .HasMaxLength(100);

            this.Property(t => t.Item)
                .HasMaxLength(100);

            this.Property(t => t.Produto)
                .HasMaxLength(100);

            this.Property(t => t.Grupo)
                .HasMaxLength(100);

            this.Property(t => t.SubGrupo)
                .HasMaxLength(100);

            this.Property(t => t.Linha)
                .HasMaxLength(100);

            this.Property(t => t.Ncm)
                .HasMaxLength(100);

            this.Property(t => t.Aliq)
                .HasMaxLength(100);

            this.Property(t => t.RsUnit)
                .HasMaxLength(100);

            this.Property(t => t.DescUnit)
                .HasMaxLength(100);

            this.Property(t => t.DescPorc)
                .HasMaxLength(100);

            this.Property(t => t.RsUnitreal)
                .HasMaxLength(100);

            this.Property(t => t.Unid)
                .HasMaxLength(100);

            this.Property(t => t.Qtd)
                .HasMaxLength(100);

            this.Property(t => t.RsTotal)
                .HasMaxLength(100);

            this.Property(t => t.RsTotalReal)
                .HasMaxLength(100);

            this.Property(t => t.CodCli)
                .HasMaxLength(100);

            this.Property(t => t.CodVeiculo)
                .HasMaxLength(100);

            this.Property(t => t.Vendedor)
                .HasMaxLength(100);

            this.Property(t => t.Tipo)
                .HasMaxLength(100);

            this.Property(t => t.Usuario)
                .HasMaxLength(100);

            this.Property(t => t.Unidade)
                .HasMaxLength(100);

            this.Property(t => t.Nf)
                .HasMaxLength(100);

            this.Property(t => t.Promocao)
                .HasMaxLength(100);

            this.Property(t => t.Caixa)
                .HasMaxLength(100);

            this.Property(t => t.Turno)
                .HasMaxLength(100);

            this.Property(t => t.AliquestPorc)
                .HasMaxLength(100);

            this.Property(t => t.Aliqfedporc)
                .HasMaxLength(100);

            this.Property(t => t.Aliquestval)
                .HasMaxLength(100);

            this.Property(t => t.Aliqfedval)
                .HasMaxLength(100);

            this.Property(t => t.Atendente)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("sosportalmovimentacao");
            this.Property(t => t.IdMovimentacao).HasColumnName("IdMovimentacao");
            this.Property(t => t.IdProduto).HasColumnName("IdProduto");
            this.Property(t => t.IdOperacao).HasColumnName("IdOperacao");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");
            this.Property(t => t.Orcamento).HasColumnName("Orcamento");
            this.Property(t => t.Barras).HasColumnName("Barras");
            this.Property(t => t.Item).HasColumnName("Item");
            this.Property(t => t.Produto).HasColumnName("Produto");
            this.Property(t => t.Grupo).HasColumnName("Grupo");
            this.Property(t => t.SubGrupo).HasColumnName("SubGrupo");
            this.Property(t => t.Linha).HasColumnName("Linha");
            this.Property(t => t.Ncm).HasColumnName("Ncm");
            this.Property(t => t.Aliq).HasColumnName("Aliq");
            this.Property(t => t.RsUnit).HasColumnName("RsUnit");
            this.Property(t => t.DescUnit).HasColumnName("DescUnit");
            this.Property(t => t.DescPorc).HasColumnName("DescPorc");
            this.Property(t => t.RsUnitreal).HasColumnName("RsUnitreal");
            this.Property(t => t.Unid).HasColumnName("Unid");
            this.Property(t => t.Qtd).HasColumnName("Qtd");
            this.Property(t => t.RsTotal).HasColumnName("RsTotal");
            this.Property(t => t.RsTotalReal).HasColumnName("RsTotalReal");
            this.Property(t => t.CodCli).HasColumnName("CodCli");
            this.Property(t => t.CodVeiculo).HasColumnName("CodVeiculo");
            this.Property(t => t.Vendedor).HasColumnName("Vendedor");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Hora).HasColumnName("Hora");
            this.Property(t => t.Usuario).HasColumnName("Usuario");
            this.Property(t => t.Unidade).HasColumnName("Unidade");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Nf).HasColumnName("Nf");
            this.Property(t => t.Promocao).HasColumnName("Promocao");
            this.Property(t => t.Caixa).HasColumnName("Caixa");
            this.Property(t => t.Turno).HasColumnName("Turno");
            this.Property(t => t.AliquestPorc).HasColumnName("AliquestPorc");
            this.Property(t => t.Aliqfedporc).HasColumnName("Aliqfedporc");
            this.Property(t => t.Aliquestval).HasColumnName("Aliquestval");
            this.Property(t => t.Aliqfedval).HasColumnName("Aliqfedval");
            this.Property(t => t.Atendente).HasColumnName("Atendente");

            // Relationships
            this.HasRequired(t => t.sosportalcliente);
                //.WithMany(t => t.sosportalmovimentacaos)
                //.HasForeignKey(d => d.IdCliente);
            this.HasRequired(t => t.sosportaloperacao)
                .WithMany(t => t.sosportalmovimentacaos)
                .HasForeignKey(d => d.IdOperacao);
            this.HasRequired(t => t.sosportalproduto)
                .WithMany(t => t.sosportalmovimentacaos)
                .HasForeignKey(d => d.IdProduto);

        }
    }
}
