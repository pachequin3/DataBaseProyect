using prueba1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using prueba1.Permisos;
namespace prueba1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [PermisosRol(Rol.Pediatra, Rol.Paciente)]
       
        public ActionResult Laboratorio()
        {

            return View();
        }
        [PermisosRol(Rol.Pediatra)]
        public ActionResult Informes()
        {

            return View();
        }
        [PermisosRol(Rol.Pediatra)]
        public ActionResult Resultados()
        {

            return View();
        }
        [PermisosRol(Rol.Pediatra)]
        public ActionResult Notas_Evolucion()
        {

            return View();
        }
        [PermisosRol(Rol.Pediatra)]
        public ActionResult Historial_Clinico()
        {
            

            return View();
        }
        [PermisosRol(Rol.Pediatra, Rol.Paciente)]
        public ActionResult Controles()
        {
           

            return View();
        }


        public ActionResult SinPermiso()
        {
            ViewBag.Message = "Usted no cuenta con permisos para ver esta pagina";

            return View();
        }

        public ActionResult CerrarSesion()
        {

            FormsAuthentication.SignOut();
            Session["Usuario"] = null;


            return RedirectToAction("Index", "Acceso");



        }
    }
}