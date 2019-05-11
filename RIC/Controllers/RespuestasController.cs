using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using RIC.DL;
using RIC.Controllers;

namespace RIC.Views.Respuestas
{
    public class RespuestasController : Controller
    {
        public ActionResult Index()
        {
            return View("VistaIndexRespuesta");
        }


        [ActionName("73092df3-02a7-4878-b1ac-7b26cfa27d88")]
        public JsonResult Testing()
        {
            try
            {
                var blTest = RespuestasDL.Test();

                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.RequestsCorrect.OK,
                    iIdEstatus = blTest ? Enumeradores.RequestsCorrect.Accepted : Enumeradores.RequestsCorrect.NoContent,
                    strMensaje = blTest ? "Success" : "No content",
                    data = blTest
                };

                return Json(jsonDataResult, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.CustomerErrors.BadRequest,
                    iIdEstatus = Enumeradores.CustomerErrors.Conflict,
                    strMensaje = string.Format("Se ha presentado el siguiente error: {0}", ex.Message)
                };

                return Json(jsonDataResult, JsonRequestBehavior.AllowGet);
            }
        }






        public ActionResult Crear()
        {
            return View("VistaCrearRespuesta");
        }

        public ActionResult Borrar()
        {
            return View("VistaBorrarRespuesta");
        }

        public ActionResult Modificar()
        {
            return View("VistaModificarRespuesta");
        }

        public ActionResult Buscar()
        {
            return View("VistaBuscarRespuesta");
        }

        public ActionResult Listar()
        {
            return View("VistaListarRespuesta");
        }

    }
}