using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RIC.Views.Respuestas
{
    public class RespuestasController : Controller
    {
        public IActionResult Index()
        {
            return View("VistaIndexRespuesta");
        }

        public IActionResult crear()
        {
            return View("VistaCrearRespuesta");
        }

        public IActionResult borrar()
        {
            return View("VistaBorrarRespuesta");
        }

        public IActionResult modificar()
        {
            return View("VistaModificarRespuesta");
        }

        public IActionResult buscar()
        {
            return View("VistaBuscarRespuesta");
        }

        public IActionResult listar()
        {
            return View("VistaListarRespuesta");
        }

    }
}