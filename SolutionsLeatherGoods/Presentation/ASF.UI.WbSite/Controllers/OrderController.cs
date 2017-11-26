using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult CreateOrder()
        {
            var email = User.Identity.Name;
            var orderProcess = new OrderProcess();
            orderProcess.CrearOrder(email);

            return RedirectToAction("Index","Product");
        }


        public ActionResult Index()
        {

            return View();
        }
    }
}