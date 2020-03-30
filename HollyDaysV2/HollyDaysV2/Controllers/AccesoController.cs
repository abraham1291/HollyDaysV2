using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HollyDaysV2.Models;

namespace HollyDaysV2.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entrar(string usuario, string contrasena) {
            try {
                using (hollydaysEntities db = new hollydaysEntities()) {
                    var lista = from d in db.Empleados
                                where d.email == usuario && d.contrasena == contrasena && d.estatus == 1
                                select d;

                    if (lista.Count() > 0)
                    {
                        Session["User"] = lista.First();
                        return Content("1");
                    }
                    else {
                        return Content("Datos incorrectos");
                    }
                }
            }
            catch (Exception ex) {
                return Content("Ocurrio un error" +ex.Message);
            }
        }
    }
}