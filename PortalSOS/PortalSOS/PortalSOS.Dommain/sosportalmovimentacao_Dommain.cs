using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportalmovimentacao_Dommain
    {
        public int IdMovimentacao { get; set; }
        public int IdProduto { get; set; }
        public int IdOperacao { get; set; }
        public int IdCliente { get; set; }
        public Nullable<int> Orcamento { get; set; }
        public string Barras { get; set; }
        public string Item { get; set; }
        public string Produto { get; set; }
        public string Grupo { get; set; }
        public string SubGrupo { get; set; }
        public string Linha { get; set; }
        public string Ncm { get; set; }
        public string Aliq { get; set; }
        public string RsUnit { get; set; }
        public string DescUnit { get; set; }
        public string DescPorc { get; set; }
        public string RsUnitreal { get; set; }
        public string Unid { get; set; }
        public string Qtd { get; set; }
        public string RsTotal { get; set; }
        public string RsTotalReal { get; set; }
        public string CodCli { get; set; }
        public string CodVeiculo { get; set; }
        public string Vendedor { get; set; }
        public string Tipo { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<System.DateTime> Hora { get; set; }
        public string Usuario { get; set; }
        public string Unidade { get; set; }
        public bool Status { get; set; }
        public string Nf { get; set; }
        public string Promocao { get; set; }
        public string Caixa { get; set; }
        public string Turno { get; set; }
        public string AliquestPorc { get; set; }
        public string Aliqfedporc { get; set; }
        public string Aliquestval { get; set; }
        public string Aliqfedval { get; set; }
        public string Atendente { get; set; }
        public virtual sosportalcliente_Dommain sosportalcliente { get; set; }
        public virtual sosportaloperacao_Dommain sosportaloperacao { get; set; }
        public virtual sosportalproduto_Dommain sosportalproduto { get; set; }
            }
}
