using ASF.Data.DbContext;
using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet]
        public ActionResult Index()
        {
            var email = User.Identity.Name;
            var cartProcess = new CartProcess();
            var cartCompleta = cartProcess.ObtenerCartCompleta(email);

            return View(cartCompleta);
        }

        [HttpPost]
        public ActionResult UpdateCart(int cantidad, int productId, double price)
        {
            var email = User.Identity.Name;
            var cartProcess = new CartProcess();

            cartProcess.AddToCart(cantidad, productId, email, price);

            return RedirectToAction("Index", "Product");
        }

        public ActionResult Remove(int id)
        {
            var cartProcess = new CartProcess();
            cartProcess.Remove(id);

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Images(int id)
        {
            var context = new LeatherGoodsEntities();
            byte[] imageData = context.Product.FirstOrDefault(i => i.Id == id)?.Image;
            if (imageData != null)
            {
                return File(imageData, "image/png", "image/jpg");
            }
            return null;
        }
    }
}