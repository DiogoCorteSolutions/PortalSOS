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
    public class SegmentoController : BaseController
    {
        private readonly PortalSOS.Application.Perfil_Application _perfilApp;
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;

        public SegmentoController()
        {
            this._perfilApp = new Application.Perfil_Application();
            this._clienteApp = new Application.Cliente_Application();
        }
        //
        // GET: /Perfil/
        //[CustomAuthorize]
        public ActionResult SegmentoLista()
        {
            return View(this._perfilApp.ListarTodos().Where(x => x.Tipo == 2 && x.DescricaoTipo == "Segmento"));

        }
        [CustomAuthorize]
        public ActionResult SegmentoCreate()
        {
            var model = new Perfil_Models();
            model.DdlTipoPerfilLista = TipoPerfilLista();

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        //[HttpPost]
        public ActionResult SegmentoCreate(Perfil_Models model)
        {
            var resultado = this._perfilApp.ExistePerfilSegm(model.Perfil);
            if (resultado != true)
            {

                try
                {
                    var dommain = new sosportalperfil_Dommain
                    {

                        Perfil = model.Perfil,
                        DataCadastro = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                        Status = true,
                        DescricaoTipo = "Segmento",
                        Tipo = 2,

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
                return RedirectToAction("SegmentoLista", "segmento");
            }
            else
            {
                TempData["msgsucesso"] = "Esse nome ja esta cadastrado em nossa base!";

            }
            return RedirectToAction("segmentoLista", "segmento");
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

                    return RedirectToAction("SegmentoLista", "Segmento");

                }

                catch (Exception exception)
                {
                    TempData["msgerror"] = exception.Message.ToString();
                    return RedirectToAction("SegmentoLista", "Segmento");
                }

            }
            else
            {
                TempData["msgsucesso"] = "Não é possivel excluir um perfil que ja tem vinculo com cliente!";


            }
            return RedirectToAction("SegmentoLista", "Segmento");

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
