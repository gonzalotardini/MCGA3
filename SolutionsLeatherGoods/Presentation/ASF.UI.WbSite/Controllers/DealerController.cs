using ASF.Entities;
using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{

    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult Index()
        {
            var dealerProcess = new DelaerProcess();
            var listaDealer = new List<Dealer>();

            listaDealer = dealerProcess.SelectAll();
            return View(listaDealer);
        }

        public ActionResult Details(int id)
        {
            var dealerProcess = new DelaerProcess();
            var dealer = dealerProcess.SelectOne(id);

            return View(dealer);
        }
    }
}