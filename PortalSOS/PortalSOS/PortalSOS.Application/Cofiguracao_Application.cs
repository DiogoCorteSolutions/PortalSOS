using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalSOS.Dommain;

namespace PortalSOS.Application
{
    public class Cofiguracao_Application
    {
        private readonly PortalSOS.Repositories.Cofiguracao_Repositories _repository;
        public Cofiguracao_Application()
        {
            this._repository = new Repositories.Cofiguracao_Repositories();
        }
        //public IList<sosportalmenu_Dommain> ListarMenuPorClienteId(int clienteId, int idperfil)
        //{
        //    var resultMenu = this._repository.ListarConfigurcooesPorClienteId(clienteId);

        //    var result = new List<sosportalmenu_Dommain>();

        //    var controller = resultMenu.Where(x => x.IdController == 0);
        //    var action = resultMenu.Where(x => x.IdController != 0 && x.ControllerAction.ToLower()
        //    != "clienteeditar" && x.ControllerAction.ToLower() != "clientedetails");

        //    foreach (var item in controller)
        //    {
        //        var obj = new sosportalmenu_Dommain
        //        {
        //            Controller = item.ControllerAction,
        //            MenuId = item.IdConfiguracao
        //        };

        //        var actionController = action.Where(x => x.IdController == item.IdConfiguracao);
        //        if (actionController == null || actionController.Count() <= 0)
        //            continue;

        //        foreach (var itema in actionController)
        //        {
        //            var objSub = new sosportalmenu_Dommain
        //            {
        //                Controller = item.ControllerAction,
        //                Action = itema.ViewName,
        //                MenuId = itema.IdConfiguracao
        //            };
        //            obj.SubMenu.Add(objSub);
        //        }
        //        result.Add(obj);
        //    }

        //    return result;
        //}
        public IList<sosportalmenu_Dommain> ListarMenuPorClienteId(int clienteId, int idperfil)

        {
            var resultMenu = this._repository.ListarConfigurcooesPorClienteId(clienteId, idperfil);
            //var resultMenuPerfil = this._repository.ListarConfigurcooesPorClienteId(idperfil);

            var result = new List<sosportalmenu_Dommain>();

            var controller = resultMenu.Where(x => x.IdController == 0);
            var action = resultMenu.Where(x => x.IdController != 0 && x.ControllerAction.ToLower()
            != "clienteeditar" && x.ControllerAction.ToLower() != "clientedetails" 
            && x.ControllerAction.ToLower() != "excluir" && x.ControllerAction.ToLower() != "Editar"
            && x.ControllerAction.ToLower() != "edit" && x.ControllerAction.ToLower() != "home"
            && x.ControllerAction.ToLower() != "index" && x.ControllerAction.ToLower() != "details");

            foreach (var item in controller)
            {
                var obj = new sosportalmenu_Dommain
                {
                    Controller = item.ControllerAction,
                    MenuId = item.IdConfiguracao
                };

                var actionController = action.Where(x => x.IdController == item.IdConfiguracao);
                if (actionController == null || actionController.Count() <= 0)
                    continue;

                foreach (var itema in actionController)
                {
                    var objSub = new sosportalmenu_Dommain
                    {
                        Controller = item.ControllerAction,
                        Action = itema.ViewName,
                        MenuId = itema.IdConfiguracao
                    };
                    obj.SubMenu.Add(objSub);
                }
                result.Add(obj);
            }

            return result;
        }

        public IList<sosportalconfiguracao_Dommain> ListarConfigurcooesPorClienteId(int clienteIdLoja, int idperfil)
        {
            return this._repository.ListarConfigurcooesPorClienteId(clienteIdLoja, idperfil);
        }
        public IList<sosportalconfiguracao_Dommain> ListarConfigurcooesPorClienteIdAcesso(int clienteIdLoja, int idperfil)
        {
            return this._repository.ListarConfigurcooesPorClienteIdAcesso(clienteIdLoja, idperfil);
        }


        //    public IList<sosportalconfiguracao_Dommain> ListarConfigurcooesPorClienteId(int clienteIdLoja)
        //{
        //    return this._repository.ListarConfigurcooesPorClienteId(clienteIdLoja);
        //}
        public IList<sosportalconfiguracao_Dommain> ListarConfigurcooesPorLojaId(int clienteIdLoja)
        {
            return this._repository.ListarConfigurcooesPorLojaId(clienteIdLoja);
        }
        //public IList<ConfiguracaoPorLoja_Dommain> ListarMenuPorIdPessoaLoja(int clienteIdLoja)
        //{
        //    return this._repository.ListarMenuPorIdPessoaLoja(clienteIdLoja);
        //}
        public List<sosportalconfiguracao_Dommain> ListarTodos()
        {
            return this._repository.ListarTodos();
        }
        public void Salvar(sosportalconfiguracao_Dommain dommain)
        {
            this._repository.Salvar(dommain);
        }
        public void Atualizar(sosportalconfiguracao_Dommain dommain)
        {
            this._repository.Atualizar(dommain);
        }
        public void Excluir(int id)
        {
            this._repository.Excluir(id);
        }
        public sosportalconfiguracao_Dommain ListarPorId(int id)
        {
            return this._repository.ListarPorId(id);
        }
        public IEnumerable<sosportalconfiguracao_Dommain> ListarActioPorIdController(int idController)
        {
            return this._repository.ListarActioPorIdController(idController);
        }
        public bool ExisteControlle(string controllerAction)
        {
            return this._repository.ExisteConrolle(controllerAction);
        }

        public bool ExisteAction(string action, int idconctroller)
        {
            return this._repository.ExisteAction(action, idconctroller);
        }

    }
}
