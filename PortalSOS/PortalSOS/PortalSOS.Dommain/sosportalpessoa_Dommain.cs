using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportalpessoa_Dommain
    {
        public sosportalpessoa_Dommain()
        {
            this.sosportalmovimentacaos = new List<sosportalmovimentacao_Dommain>();
            this.sosportalconfiguracaopessoa = new List<sosportalconfiguracaopessoa_Dommain>();
        }

        public int IdPessoa { get; set; }
        public int IdPerfil { get; set; }
        public int IdLoja { get; set; }
        public string Pessoa { get; set; }
        public string Razao { get; set; }
        public string InscMunicipal { get; set; }
        public string Cnpj { get; set; }
        public string Estadual { get; set; }
        public string Endereco { get; set; }
        public string N { get; set; }
        public string Compl { get; set; }
        public string Bairro { get; set; }
        public string CodMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Cnae { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string TipodeTel { get; set; }
        public string TipoEnd { get; set; }
        public string Operadora { get; set; }
        public string Contato { get; set; }
        public string CodVenda { get; set; }
        public string Licenca { get; set; }
        public string Ativacao { get; set; }
        public string Total { get; set; }
        public string Obs { get; set; }
        public string LimiteCred { get; set; }
        public bool Status { get; set; }
        public string Emitente { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Classificacao { get; set; }
        public string CPF { get; set; }
        public string Tipo { get; set; }
        public string Representante { get; set; }
        public string Ultilizado { get; set; }
        public string Senha { get; set; }
        public string RG { get; set; }
        public virtual sosportalloja_Dommain sosportalloja { get; set; }
        public virtual ICollection<sosportalmovimentacao_Dommain> sosportalmovimentacaos { get; set; }
        public virtual ICollection<sosportalconfiguracaopessoa_Dommain> sosportalconfiguracaopessoa { get; set; }
        
        public virtual sosportalperfil_Dommain sosportalperfil { get; set; }
    }
}
