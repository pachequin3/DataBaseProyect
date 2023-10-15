using prueba1.Logica;
using prueba1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace prueba1.Controllers
{
    public class AccesoController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string usuario, string clave)
        {
            Usuarios objeto = new LO_Usuario().EncontrarUsuario(usuario, clave);

            if (objeto.Nombre != null)
            {

                FormsAuthentication.SetAuthCookie(objeto.Usuario, false);

                Session["Usuario"] = objeto;

                return RedirectToAction("Index", "Home");
            }



            return View();
        }
        static string cadena = "Data Source=DESKTOP-VN7CRBV\\MSSQLSERVER01 ;Initial Catalog=Pediatria;Integrated Security=true";
        public ActionResult Regsitrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Usuarios oUsuarios)
        {
            bool registrado;
            string mensaje;

            if (oUsuarios.Clave == oUsuarios.ConfirmarClave)
            {

            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.Parameters.AddWithValue("Nombre", oUsuarios.Nombre);
                cmd.Parameters.AddWithValue("Apellido", oUsuarios.Apellido);
                cmd.Parameters.AddWithValue("Usuario", oUsuarios.Usuario);
                cmd.Parameters.AddWithValue("Clave", oUsuarios.Clave);
                cmd.Parameters.AddWithValue("IdRol", 2) ; 
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();


            }

            ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                return View();
            }

        }
        private int ObtenerIdRolParaNuevoUsuario(int x)
        {
             x = 2;
            // Aquí puedes implementar la lógica para determinar el IdRol, por ejemplo, basado en un rol predeterminado o algún otro criterio
            // Por ahora, asignaremos un valor predeterminado (por ejemplo, 2 para 'Paciente')
            return x;
        }
    }
}