using CasoEstudio2.Entities;
using CasoEstudio2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CasoEstudio2.Controllers
{
    public class CasasController : Controller
    {
        private readonly ICasasModel _casasModel;

        public CasasController(ICasasModel casasModel)
        {
            _casasModel = casasModel;
        }

        [HttpGet]
        public IActionResult ConsultarCasas()
        {
            var datos = _casasModel.ConsultarCasas();
            return View(datos?.Objetos);
        }

        [HttpGet]
        public IActionResult AlquilarCasas()
        {
            var datos = _casasModel.ConsultarCasasDisponibles();
            return View(datos);
        }

        [HttpPost]
        public IActionResult RegistrarAlquiler(CasasEntRespuesta entidad)
        {
            var datos = _casasModel.AlquilarCasa(entidad);
            if (datos?.Codigo != 1)
            {
                ViewBag.Mensaje = datos?.Mensaje;
                return View("AlquilarCasas");
            }

            return RedirectToAction("ConsultarCasas", "Casas");
        }
    }
}
