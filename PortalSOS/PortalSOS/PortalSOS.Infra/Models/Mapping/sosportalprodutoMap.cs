using PortalSOS.Dommain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PortalSOS.Infra.Models.Mappingg
{
    public class sosportalprodutoMap : EntityTypeConfiguration<sosportalproduto_Dommain>
    {
        public sosportalprodutoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdProduto);

            // Properties
            this.Property(t => t.Barras)
                .HasMaxLength(100);

            this.Property(t => t.Ref)
                .HasMaxLength(100);

            this.Property(t => t.Forn)
                .HasMaxLength(100);

            this.Property(t => t.Cfop)
                .HasMaxLength(100);

            this.Property(t => t.Prod)
                .HasMaxLength(100);

            this.Property(t => t.Unidade)
                .HasMaxLength(100);

            this.Property(t => t.CodGen)
                .HasMaxLength(100);

            this.Property(t => t.Gen)
                .HasMaxLength(100);

            this.Property(t => t.Sub)
                .HasMaxLength(100);

            this.Property(t => t.Linha)
                .HasMaxLength(100);

            this.Property(t => t.ValidDias)
                .HasMaxLength(100);

            this.Property(t => t.Lote)
                .HasMaxLength(100);

            this.Property(t => t.Cor)
                .HasMaxLength(100);

            this.Property(t => t.Tipo)
                .HasMaxLength(100);

            this.Property(t => t.Atual)
                .HasMaxLength(100);

            this.Property(t => t.Minimo)
                .HasMaxLength(100);

            this.Property(t => t.Ideial)
                .HasMaxLength(100);

            this.Property(t => t.Bruto)
                .HasMaxLength(100);

            this.Property(t => t.Ucom)
                .HasMaxLength(100);

            this.Property(t => t.Ncm)
                .HasMaxLength(100);

            this.Property(t => t.Utrib)
                .HasMaxLength(100);

            this.Property(t => t.Ubal)
                .HasMaxLength(100);

            this.Property(t => t.Validade)
                .HasMaxLength(100);

            this.Property(t => t.Ali)
                .HasMaxLength(100);

            this.Property(t => t.Stat)
                .HasMaxLength(100);

            this.Property(t => t.Cust)
                .HasMaxLength(100);

            this.Property(t => t.Descricao)
                .HasMaxLength(100);

            this.Property(t => t.Subtri)
                .HasMaxLength(100);

            this.Property(t => t.Ipi)
                .HasMaxLength(100);

            this.Property(t => t.Dificms)
                .HasMaxLength(100);

            this.Property(t => t.Custoimp)
                .HasMaxLength(100);

            this.Property(t => t.Comissadi)
                .HasMaxLength(100);

            this.Property(t => t.Mgven)
                .HasMaxLength(100);

            this.Property(t => t.Varejo)
                .HasMaxLength(100);

            this.Property(t => t.Atacado)
                .HasMaxLength(100);

            this.Property(t => t.Mgvenajus)
                .HasMaxLength(100);

            this.Property(t => t.Vavtot)
                .HasMaxLength(100);

            this.Property(t => t.Flex)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.AlisetPorc)
                .HasMaxLength(100);

            this.Property(t => t.Aliestval)
                .HasMaxLength(100);

            this.Property(t => t.AlifedPorc)
                .HasMaxLength(100);

            this.Property(t => t.Alifedval)
                .HasMaxLength(100);

            this.Property(t => t.desccncm)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("sosportalproduto");
            this.Property(t => t.IdProduto).HasColumnName("IdProduto");
            this.Property(t => t.IdPerfil).HasColumnName("IdPerfil");
            this.Property(t => t.Atualizado).HasColumnName("Atualizado");
            this.Property(t => t.Barras).HasColumnName("Barras");
            this.Property(t => t.Ref).HasColumnName("Ref");
            this.Property(t => t.Forn).HasColumnName("Forn");
            this.Property(t => t.Cfop).HasColumnName("Cfop");
            this.Property(t => t.Prod).HasColumnName("Prod");
            this.Property(t => t.Unidade).HasColumnName("Unidade");
            this.Property(t => t.CodGen).HasColumnName("CodGen");
            this.Property(t => t.Gen).HasColumnName("Gen");
            this.Property(t => t.Sub).HasColumnName("Sub");
            this.Property(t => t.Linha).HasColumnName("Linha");
            this.Property(t => t.ValidDias).HasColumnName("ValidDias");
            this.Property(t => t.ValidData).HasColumnName("ValidData");
            this.Property(t => t.Lote).HasColumnName("Lote");
            this.Property(t => t.Cor).HasColumnName("Cor");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Atual).HasColumnName("Atual");
            this.Property(t => t.Minimo).HasColumnName("Minimo");
            this.Property(t => t.Ideial).HasColumnName("Ideial");
            this.Property(t => t.Bruto).HasColumnName("Bruto");
            this.Property(t => t.Ucom).HasColumnName("Ucom");
            this.Property(t => t.Ncm).HasColumnName("Ncm");
            this.Property(t => t.Utrib).HasColumnName("Utrib");
            this.Property(t => t.Ubal).HasColumnName("Ubal");
            this.Property(t => t.Validade).HasColumnName("Validade");
            this.Property(t => t.Ali).HasColumnName("Ali");
            this.Property(t => t.Stat).HasColumnName("Stat");
            this.Property(t => t.Cust).HasColumnName("Cust");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Subtri).HasColumnName("Subtri");
            this.Property(t => t.Ipi).HasColumnName("Ipi");
            this.Property(t => t.Dificms).HasColumnName("Dificms");
            this.Property(t => t.Custoimp).HasColumnName("Custoimp");
            this.Property(t => t.Comissadi).HasColumnName("Comissadi");
            this.Property(t => t.Mgven).HasColumnName("Mgven");
            this.Property(t => t.Varejo).HasColumnName("Varejo");
            this.Property(t => t.Atacado).HasColumnName("Atacado");
            this.Property(t => t.Mgvenajus).HasColumnName("Mgvenajus");
            this.Property(t => t.Vavtot).HasColumnName("Vavtot");
            this.Property(t => t.Imagem).HasColumnName("Imagem");
            this.Property(t => t.Tam).HasColumnName("Tam");
            this.Property(t => t.Flex).HasColumnName("Flex");
            this.Property(t => t.AlisetPorc).HasColumnName("AlisetPorc");
            this.Property(t => t.Aliestval).HasColumnName("Aliestval");
            this.Property(t => t.AlifedPorc).HasColumnName("AlifedPorc");
            this.Property(t => t.Alifedval).HasColumnName("Alifedval");
            this.Property(t => t.desccncm).HasColumnName("desccncm");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
