using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cust_DVDRent.Controllers
{
    public class HomeDVDController : Controller
    {
        // GET: HomeDVD
        public ActionResult Index()
        {
            return View();
        }
    }
}