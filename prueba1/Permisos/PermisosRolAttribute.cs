using prueba1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba1.Permisos
{
    public class PermisosRolAttribute : ActionFilterAttribute
    {
        private List<Rol> rolesPermitidos;

        public PermisosRolAttribute(params Rol[] roles)
        {
            rolesPermitidos = roles.ToList();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                Usuarios usuario = HttpContext.Current.Session["Usuario"] as Usuarios;

                if (!rolesPermitidos.Contains(usuario.IdRol))
                {
                    filterContext.Result = new RedirectResult("~/Home/SinPermiso");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}