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
            orderProcess.CrearOrderCabecera(email);
            return View();
        }
    }
}