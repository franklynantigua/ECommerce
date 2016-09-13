using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private  ECommerceContext db = new ECommerceContext();
        public ActionResult Index()
        {
            //PARA VERIFICAR CUAL ES EL USUARIO QUE ESTA LOGEADO Y PASARLE
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            return View(user);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}