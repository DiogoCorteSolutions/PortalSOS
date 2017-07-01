using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalSOS.Dommain;
using PortalSOS.Web.Helpers;
using PortalSOS.Web.Models;

namespace PortalSOS.Web.Controllers
{
    [CustomAuthorize]
    public class PerfilController : BaseController
    {
        private readonly PortalSOS.Application.Perfil_Application _perfilApp;
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;

        public PerfilController()
        {
            this._perfilApp = new Application.Perfil_Application();
            this._clienteApp = new Application.Cliente_Application();
        }
        //
        // GET: /Perfil/
        //[CustomAuthorize]
        public ActionResult PerfilLista()
        {
            return View(this._perfilApp.ListarTodos().Where(x => x.Tipo == 1 && x.DescricaoTipo == "Perfil"));

        }
        [CustomAuthorize]
        public ActionResult PerfilCreate()
        {
            var model = new Perfil_Models();
            model.DdlTipoPerfilLista = TipoPerfilLista();

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        //[HttpPost]
        public ActionResult PerfilCreate(Perfil_Models model)
        {
            var result = this._perfilApp.ExistePerfilSegm(model.Perfil);

            if (result != true)
            {

                model.DdlTipoPerfilLista = TipoPerfilLista();

                try
                {
                    var dommain = new sosportalperfil_Dommain
                    {

                        Perfil = model.Perfil,
                        DataCadastro = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                        Status = true,
                        DescricaoTipo = "Perfil",
                        Tipo = 1,

                    };

                    if (ModelState.IsValid)
                    {
                        this._perfilApp.Salvar(dommain);
                        TempData["msgsucesso"] = "Registro salvo com sucesso";
                        return View(model);

                    }

                }
                catch (Exception exception)
                {
                    TempData["msgerror"] = exception.Message.ToString();
                    return View(model);
                }

                return RedirectToAction("perfilLista", "perfil");

            }
            else
            {
                TempData["msgsucesso"] = "Essa classificação já esta cadastrada!";
            }
            return RedirectToAction("perfilLista", "perfil");

           
        }
        public ActionResult Edit(int id)
        {

            var filtro = this._perfilApp.ListarPorId(id);

            var model = new Perfil_Models
            {
                IdPerfil = filtro.IdPerfil,
                Perfil = filtro.Perfil,


            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Perfil_Models model)
        {
            try
            {
                var filtro = this._perfilApp.ListarPorId(model.IdPerfil);

                filtro.IdPerfil = model.IdPerfil;
                filtro.Perfil = model.Perfil;

                if (ModelState.IsValid)
                {
                    this._perfilApp.Atualizar(filtro);
                    TempData["msgsucesso"] = "Registro atualizado com sucesso!";

                }


                return View(model);
            }
            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return View(model);
            }
        }
        public ActionResult Excluir(int id)
        {

            var perfil = this._clienteApp.ListarPorIdPerfil(id);
            if (perfil == null)
            {
                try
                {
                    this._perfilApp.Excluir(id);
                    TempData["msgsucesso"] = "Registro excluido com sucesso!";

                    return RedirectToAction("PerfilLista", "perfil");

                }

                catch (Exception exception)
                {
                    TempData["msgerror"] = exception.Message.ToString();
                    return RedirectToAction("PerfilLista", "perfil");
                }

            }
            else
            {
                TempData["msgsucesso"] = "Não é possivel excluir um segmento que ja tem vinculo com cliente!";


            }
            return RedirectToAction("PerfilLista", "perfil");

        }
        public ActionResult Details(int id)
        {
            var filtro = this._perfilApp.ListarPorId(id);

            var model = new Perfil_Models
            {
                Perfil = filtro.Perfil,
                //Tipo = filtro.Tipo,
                DescricaoTipo = filtro.DescricaoTipo,
                DataCadastro = filtro.DataCadastro,


            };

            return View(model);
        }


    }
}
