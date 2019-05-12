using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using RIC.DL;
using RIC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace RIC.Views.Respuestas
{
    public class RespuestasController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View("VistaIndexRespuesta");
        }


        [System.Web.Mvc.ActionName("73092df3-02a7-4878-b1ac-7b26cfa27d88")]
        public System.Web.Mvc.JsonResult Testing()
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

                return new System.Web.Mvc.JsonResult(){

                    Data = jsonDataResult,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet

                };

            }
            catch (Exception ex)
            {
                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.CustomerErrors.BadRequest,
                    iIdEstatus = Enumeradores.CustomerErrors.Conflict,
                    strMensaje = string.Format("Se ha presentado el siguiente error: {0}", ex.Message)
                };

                return new System.Web.Mvc.JsonResult()
                {

                    Data = jsonDataResult,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet

                };
            }
        }






        public IActionResult Crear()
        {
            return View("VistaCrearRespuesta");
        }

        public IActionResult Borrar()
        {
            return View("VistaBorrarRespuesta");
        }

        public IActionResult Modificar()
        {
            return View("VistaModificarRespuesta");
        }

        public IActionResult Buscar()
        {
            return View("VistaBuscarRespuesta");
        }

        public IActionResult Listar()
        {
            return View("VistaListarRespuesta");
        }

    }
}