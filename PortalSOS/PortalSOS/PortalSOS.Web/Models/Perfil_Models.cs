using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalSOS.Web.Models
{
    public class Perfil_Models : BaseModels
    {
        //public int IdPerfil { get; set; }
        //public string Perfil { get; set; }
        //public bool Status { get; set; }
        //public Nullable<System.DateTime> DataCadastro { get; set; }
        //public Nullable<System.DateTime> DataAlteracao { get; set; }


        public int IdPerfil { get; set; }
        public string Perfil { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public int Tipo { get; set; }
        public string DescricaoTipo { get; set; }
    }
}