using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ASF.Entities;

namespace ASF.UI.WbSite.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        [HttpGet]
        public ActionResult Index()
        {
            var CountryProcess = new Process.CountryProcess();
            var List = new List<Country>();
            List = CountryProcess.SelectList();          
            return View(List);
        }
    }
}