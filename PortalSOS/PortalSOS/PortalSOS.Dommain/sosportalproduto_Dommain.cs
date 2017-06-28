using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportalproduto_Dommain
    {
        public sosportalproduto_Dommain()
        {
            this.sosportalmovimentacaos = new List<sosportalmovimentacao_Dommain>();
        }

        public int IdProduto { get; set; }
        public int IdPerfil { get; set; }
        public Nullable<System.DateTime> Atualizado { get; set; }
        public string Barras { get; set; }
        public string Ref { get; set; }
        public string Forn { get; set; }
        public string Cfop { get; set; }
        public string Prod { get; set; }
        public string Unidade { get; set; }
        public string CodGen { get; set; }
        public string Gen { get; set; }
        public string Sub { get; set; }
        public string Linha { get; set; }
        public string ValidDias { get; set; }
        public Nullable<System.DateTime> ValidData { get; set; }
        public string Lote { get; set; }
        public string Cor { get; set; }
        public string Tipo { get; set; }
        public string Atual { get; set; }
        public string Minimo { get; set; }
        public string Ideial { get; set; }
        public string Bruto { get; set; }
        public string Ucom { get; set; }
        public string Ncm { get; set; }
        public string Utrib { get; set; }
        public string Ubal { get; set; }
        public string Validade { get; set; }
        public string Ali { get; set; }
        public string Stat { get; set; }
        public string Cust { get; set; }
        public string Descricao { get; set; }
        public string Subtri { get; set; }
        public string Ipi { get; set; }
        public string Dificms { get; set; }
        public string Custoimp { get; set; }
        public string Comissadi { get; set; }
        public string Mgven { get; set; }
        public string Varejo { get; set; }
        public string Atacado { get; set; }
        public string Mgvenajus { get; set; }
        public string Vavtot { get; set; }
        public string Imagem { get; set; }
        public string Tam { get; set; }
        public string Flex { get; set; }
        public string AlisetPorc { get; set; }
        public string Aliestval { get; set; }
        public string AlifedPorc { get; set; }
        public string Alifedval { get; set; }
        public string desccncm { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<sosportalmovimentacao_Dommain> sosportalmovimentacaos { get; set; }
    }
}
