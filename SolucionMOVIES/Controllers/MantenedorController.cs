using Microsoft.AspNetCore.Mvc;

using SolucionMOVIES.Peliculas;
using SolucionMOVIES.Models;


namespace SolucionMOVIES.Controllers
{
    public class MantenedorController : Controller
    {
        Actores _Actores = new Actores();
        public IActionResult Listar()
        {
            var oLista = _Actores.Listar();
            return View(oLista); //mostrará lista de artistas o de participaciones
        }

        Actores _Participaciones = new Actores(); //listar las participaciones
        public IActionResult ListarParticipaciones()
        {
            var oListaP = _Actores.ListarParticipaciones();
            return View(oListaP); //mostrará lista de artistas o de participaciones
        }

        public IActionResult Guardar()
        {
            return View();//devuelve vistas solamente html
        }
        
        [HttpPost]
        public IActionResult Guardar(actores oActores) //se trae actores del modelo de las conecxiones BD actores.cs
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _Actores.guardarActor(oActores);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                   return View();
            
            //guarda en la base de datos
        }
    }
}
