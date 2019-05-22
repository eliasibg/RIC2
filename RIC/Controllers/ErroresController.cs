using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

using RIC.DL;
using RIC.Controllers;


namespace RIC.Views.Errores
{
    public class ErroresController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View("VistaIndexErrores");
        }


        [Microsoft.AspNetCore.Mvc.ActionName("5bc24248-5cbc-4a08-ae01-e1d285f39e26")]
        public System.Web.Mvc.JsonResult ListarRespuestas()
        {
            try
            {
                var lstErrores = ErroresDL.GetErrores();

                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.RequestsCorrect.OK,
                    iIdEstatus = lstErrores.Count > 0 ? Enumeradores.RequestsCorrect.Accepted : Enumeradores.RequestsCorrect.NoContent,
                    strMensaje = lstErrores.Count > 0 ? "Success" : "No content",
                    data = lstErrores
                };

                return new System.Web.Mvc.JsonResult()
                {

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


        public IActionResult Buscar()
        {
            return View("VistaBuscarErrores");
        }

        public IActionResult Listar()
        {
            return View("VistaListarErrores");
        }

    }
}