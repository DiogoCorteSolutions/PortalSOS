using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace PortalSOS.Web.Models
{
    public class BaseModels
    {
        public IEnumerable<SelectListItem> DdlCnpj { get; set; }
        public IEnumerable<SelectListItem> DdlSegmentoListaFixo { get; set; }
        public IEnumerable<SelectListItem> DdlPerfil { get; set; }
        public IEnumerable<SelectListItem> DdlSegmentoLista { get; set; }
        public IEnumerable<SelectListItem> DdlLoja { get; set; }
        public IEnumerable<SelectListItem> DdlMovimentacao { get; set; }
        public IEnumerable<SelectListItem> DdlTipoOperacao { get; set; }
        public IEnumerable<SelectListItem> DdlOperacao { get; set; }
        public IEnumerable<SelectListItem> DdlProduto { get; set; }
        public IEnumerable<SelectListItem> DdlPessoa { get; set; }
        public IEnumerable<SelectListItem> DdlSexo { get; set; }
        public IEnumerable<SelectListItem> DdlPerfilLojaLista { get; set; }
        public IEnumerable<SelectListItem> DdlPerfilPessoaLista { get; set; }
        public IEnumerable<SelectListItem> DdlControllerlLista { get; set; }
        public IEnumerable<SelectListItem> DdlViewLista { get; set; }
        public IEnumerable<SelectListItem> DdlTipoPermissao { get; set; }
        public IEnumerable<SelectListItem> DdlClienteLista { get; set; }
        public IEnumerable<SelectListItem> DdlConfiguracaoLista { get; set; }
        public IEnumerable<SelectListItem> DdlConfiguracaoListaView { get; set; }
        public IEnumerable<SelectListItem> DdlConfiguracaoListaControlerView { get; set; }
        public IEnumerable<SelectListItem> DdlConfiguracaoListaController { get; set; }
        public IEnumerable<SelectListItem> DdlConfiguracaoListaControllerPoorFiltro { get; set; }
        public IEnumerable<SelectListItem> DdlConfiguracaoListaIndePorIdController { get; set; }
        public IEnumerable<SelectListItem> DdlEnderecoLista { get; set; }
        public IEnumerable<SelectListItem> DdlContatoLista { get; set; }
        public IEnumerable<SelectListItem> DdlUFLista { get; set; }
        public IEnumerable<SelectListItem> DdlOperadora { get; set; }
        public IEnumerable<SelectListItem> DdlTipoPessoa { get; set; }
        public IEnumerable<SelectListItem> DdlTipoTelefoneLista { get; set; }
        public IEnumerable<SelectListItem> DdlTipoEnderecoLista { get; set; }
        public IEnumerable<SelectListItem> DdlTipoPerfilLista { get; set; }

    }
}