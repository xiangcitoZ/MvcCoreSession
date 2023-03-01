using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        int numero = 1;

        public IActionResult Index()
        {
            ViewData["NUMERO"] = "Valor del número: " + this.numero;
            return View();
        }

        public IActionResult SessionSimple(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    HttpContext.Session.SetString("nombre", "Programeitor");
                    HttpContext.Session.SetString("hora",
                        DateTime.Now.ToLongTimeString());
                    ViewData["MENSAJE"] = "Datos almacenados en Session";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    ViewData["USUARIO"] =
                        HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] =
                        HttpContext.Session.GetString("hora");
                }
            }
            return View();
        }

        public IActionResult SessionPersona(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Persona persona = new Persona();
                    persona.Nombre = "Alumno";
                    persona.Email = "alumno@gmail.com";
                    persona.Edad = 25;
                    //DEBEMOS CONVERTIR EL OBJETO PERSONA
                    //A BYTE[] PARA ALMACENARLO EN SESSION
                    byte[] data = 
                        HelperBinarySession.ObjectToByte(persona);
                    //ALMACENAMOS EL OBJETO BINARIO EN SESSION
                    HttpContext.Session.Set("PERSONA", data);
                    ViewData["MENSAJE"] = "Datos almacenados";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    //EXTRAEMOS EL OBJETO PERSONA DESDE LOS BYTES[]
                    //DE SESSION
                    byte[] data = HttpContext.Session.Get("PERSONA");
                    //CONVERTIMOS EL BINARIO A OBJETO
                    Persona persona = (Persona)
                        HelperBinarySession.ByteToObject(data);
                    ViewData["PERSONA"] = persona;
                }
            }
            return View();
        }

        public IActionResult ColeccionSessionPersonas(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Persona> personas = new List<Persona>
             {
                 new Persona{ Nombre = "Lucia"
                 , Email="lucia@gmail.com", Edad = 20},
                 new Persona{ Nombre = "Andres"
                 , Email="andres@gmail.com", Edad = 40},
                 new Persona{ Nombre = "Adrian"
                 , Email="adrian@gmail.com", Edad = 23}
             };
                    byte[] data = HelperBinarySession.ObjectToByte(personas);
                    HttpContext.Session.Set("LISTAPERSONAS", data);
                    ViewData["MENSAJE"] = "Colección almacenada";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("LISTAPERSONAS");
                    List<Persona> personas = (List<Persona>)
                        HelperBinarySession.ByteToObject(data);
                    return View(personas);
                }
            }
            return View();
        }

    }
}
