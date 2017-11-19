using ASF.Data.DbContext;
using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using System.IO;

namespace ASF.UI.WbSite.Controllers
{
    public class ProductController : Controller
    {

        private List<Data.DbContext.Product> MapperProduct(IQueryable<Data.DbContext.Product> ListaRecibida)
        {
            List<Data.DbContext.Product> ListaProduct = new List<Data.DbContext.Product>();

            foreach (Data.DbContext.Product i in ListaRecibida)
            {
                var product = new Data.DbContext.Product();

                product.Id = i.Id;
                product.Image = i.Image;
                product.Price = i.Price;
                product.QuantitySold = i.QuantitySold;
                product.Rating = i.Rating;
                product.Title = i.Title;
                product.AvgStars = i.AvgStars;
                product.DealerId = i.DealerId;
                product.Description = i.Description;

                ListaProduct.Add(product);
            }

            return ListaProduct;
        }



        // GET: Product
        [Authorize]
        public ActionResult Index()
        {
            var productProcess = new ProductProcess();
            var listaProduct = productProcess.SelectAll();
            return View(listaProduct);
        }

        public ActionResult ProductDetail(int id)
        {

            var context = new LeatherGoodsEntities();
            //byte[] imageData = context.Product.FirstOrDefault(i => i.Id == id)?.Image;
            //if (imageData != null)
            //{
            //    return File(imageData, "image/jpg"); // Might need to adjust the content type based on your actual image type
            //}

            Data.DbContext.Product product = new Data.DbContext.Product();

            var consulta = from products in context.Product
                           where products.Id == id
                           select products;

            var p = MapperProduct(consulta)[0];

            return View(p);
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


        [HttpGet]
        public ActionResult Create()
        {
            var listaProduct = new List<Entities.Product>();
            var dealerProcess = new DelaerProcess();

            var listaDealer = dealerProcess.SelectAll();

            foreach (var i in listaDealer)
            {
                var product = new Entities.Product();
                        product.DealerId = i.Id;
                product.DealerDesc = i.Description;

                listaProduct.Add(product);
            }
            ViewBag.dealer = listaDealer;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Data.DbContext.Product product, HttpPostedFileBase file)
        {
            var context = new LeatherGoodsEntities();


            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();

                    product.Image = array;
                }

            }

            context.Product.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }




        public ActionResult addTocart()
        {
            return View();
        }
    }
}

