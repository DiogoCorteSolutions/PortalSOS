using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportalloja_Dommain
    {
        public sosportalloja_Dommain()
        {
            this.sosportalconfiguracaos = new List<sosportalconfiguracao_Dommain>();
            this.sosportalcontasapagars = new List<sosportalcontasapagar_Dommain>();
            this.sosportalcontasarecebers = new List<sosportalcontasareceber_Dommain>();
            this.sosportalmovimentacaos = new List<sosportalmovimentacao_Dommain>();
            this.sosportalpessoas = new List<sosportalpessoa_Dommain>();
            this.sosportalconfiguracaopessoa = new List<sosportalconfiguracaopessoa_Dommain>();
        }

        public int IdLoja { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public Nullable<System.DateTime> Datacadastro { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public bool Status { get; set; }
        public string ResponsavelCadastro { get; set; }
        public string Senha { get; set; }
        public string PerfilLoja { get; set; }
        public int IdPerfil { get; set; }
        public string CPF { get; set; }
        public string Obs { get; set; }
        public string Email { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CNAE { get; set; }
        public virtual ICollection<sosportalconfiguracao_Dommain> sosportalconfiguracaos { get; set; }
        public virtual ICollection<sosportalcontasapagar_Dommain> sosportalcontasapagars { get; set; }
        public virtual ICollection<sosportalcontasareceber_Dommain> sosportalcontasarecebers { get; set; }
        public virtual ICollection<sosportalmovimentacao_Dommain> sosportalmovimentacaos { get; set; }
        public virtual ICollection<sosportalpessoa_Dommain> sosportalpessoas { get; set; }
        public virtual ICollection<sosportalconfiguracaopessoa_Dommain> sosportalconfiguracaopessoa { get; set; }

    }
}
