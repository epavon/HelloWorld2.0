using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld2.Controllers
{
    [Authorize]
    public class WebsiteManagerController : Controller
    {
        // GET: WebsiteManager
        public ActionResult Index()
        {
            return View();
        }
    }
}