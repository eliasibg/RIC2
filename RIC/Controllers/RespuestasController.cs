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


        [Microsoft.AspNetCore.Mvc.ActionName("73092df3-02a7-4878-b1ac-7b26cfa27d88")]
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


        [Microsoft.AspNetCore.Mvc.ActionName("5a3ca528-5427-4b94-bed7-156920a71c85")]
        public System.Web.Mvc.JsonResult ListarRespuestas()
        {
            try
            {
                var lstRespuestas = RespuestasDL.GetRespuestas();

                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.RequestsCorrect.OK,
                    iIdEstatus = lstRespuestas.Count > 0 ? Enumeradores.RequestsCorrect.Accepted : Enumeradores.RequestsCorrect.NoContent,
                    strMensaje = lstRespuestas.Count > 0 ? "Success" : "No content",
                    data = lstRespuestas
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



        [Microsoft.AspNetCore.Mvc.ActionName("9427a5e6-8956-4c40-84c9-bbbd62db9484")]
        public System.Web.Mvc.JsonResult BuscarRespuestas(String strParameters)
        {
            try
            {
                string[] strParametros = strParameters.Split('|');
                string strMotivo = strParametros[0];
                

                var lstRespuestas = RespuestasDL.FindRespuestas(strMotivo);

                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.RequestsCorrect.OK,
                    iIdEstatus = lstRespuestas.Count > 0 ? Enumeradores.RequestsCorrect.Accepted : Enumeradores.RequestsCorrect.NoContent,
                    strMensaje = lstRespuestas.Count > 0 ? "Success" : "No content",
                    data = lstRespuestas
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



        [Microsoft.AspNetCore.Mvc.ActionName("fb537461-dad4-491e-a46a-7f1048ea62c5")]
        public System.Web.Mvc.JsonResult ComboMotivo()
        {
            try
            {
                var lstRespuestas = RespuestasDL.GetComboMotivo();

                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.RequestsCorrect.OK,
                    iIdEstatus = lstRespuestas.Count > 0 ? Enumeradores.RequestsCorrect.Accepted : Enumeradores.RequestsCorrect.NoContent,
                    strMensaje = lstRespuestas.Count > 0 ? "Success" : "No content",
                    data = lstRespuestas
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



        [Microsoft.AspNetCore.Mvc.ActionName("c9ef64e1-39b3-4aa7-a24b-47b107562783")]
        public System.Web.Mvc.JsonResult InsertarResp(String strParameters)
        {
            try
            {

                string[] strParametros = strParameters.Split('|');
                string strMotivo = strParametros[0];
                string strResp = strParametros[1];

                var blExito = RespuestasDL.InsertarInventario(strMotivo, strResp);

                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.RequestsCorrect.OK,
                    iIdEstatus = blExito ? Enumeradores.RequestsCorrect.Accepted : Enumeradores.RequestsCorrect.NoContent,
                    strMensaje = blExito ? "Success" : "No content",
                    data = blExito
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

        [Microsoft.AspNetCore.Mvc.ActionName("0b61f612-1089-4047-9b3c-c2d6dc2882fc")]
        public System.Web.Mvc.JsonResult ModificarResp(String strParameters)
        {
            try
            {

                string[] strParametros = strParameters.Split('|');
                string strMotivo = strParametros[0];
                string strResp = strParametros[1];
                string strIdResp = strParametros[2];


                var blExito = RespuestasDL.ModificarInventario(strMotivo, strResp, strIdResp);

                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.RequestsCorrect.OK,
                    iIdEstatus = blExito ? Enumeradores.RequestsCorrect.Accepted : Enumeradores.RequestsCorrect.NoContent,
                    strMensaje = blExito ? "Success" : "No content",
                    data = blExito
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


        [Microsoft.AspNetCore.Mvc.ActionName("93ee7b71-464f-470e-b247-7aac3e511c61")]
        public System.Web.Mvc.JsonResult LoadRespuesta(String strParameters)
        {
            try
            {
                string[] strParametros = strParameters.Split('|');
                string strIdResp = strParametros[0];


                var lstRespuestas = RespuestasDL.LoadRespuesta(strIdResp);

                var jsonDataResult = new
                {
                    iIdPeticion = Enumeradores.RequestsCorrect.OK,
                    iIdEstatus = lstRespuestas.Count > 0 ? Enumeradores.RequestsCorrect.Accepted : Enumeradores.RequestsCorrect.NoContent,
                    strMensaje = lstRespuestas.Count > 0 ? "Success" : "No content",
                    data = lstRespuestas
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