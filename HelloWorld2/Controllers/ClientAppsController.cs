using HelloWorld2.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace HelloWorld2.Controllers
{
    public class ClientAppsController : Controller
    {
        // GET: ClientApps
        public ActionResult Index()
        {
            List<string> result = new List<string>();

            foreach (var item in Directory.GetDirectories(Server.MapPath(@"~/ClientApps")))
            {
                result.Add(Path.GetFileName(item));
            }

            return View(result);
        }


        // GET: ClientApp
        public ActionResult GetApp(string appName)
        {
            ClientAppViewModel result = new ClientAppViewModel();

            if (string.IsNullOrEmpty(appName))
            {
                return HttpNotFound();
            }

            var clientAppServerPath = Server.MapPath(string.Format(@"~\ClientApps\{0}", appName));
            if (!Directory.Exists(clientAppServerPath))
            {
                return HttpNotFound();
            }

            result.ClientFiles = new Dictionary<string, string>();
            foreach (var filePath in Directory.GetFiles(clientAppServerPath, "*.js"))
            {
                result.ClientFiles[string.Format(@"~/ClientApps/{0}/{1}", appName, Path.GetFileName(filePath))] = "script";
            }
            ViewBag.Title = appName;

            return View(result);
        }
    }
}