using HelloWorld2.Models;
using HelloWorld2.Data;
using HelloWorld2.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;
using HelloWorld2.Helpers;

namespace HelloWorld2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        HelloWorldDb _db = new HelloWorldDb();

        //
        // Index
        public ActionResult Index()
        {
            var posts = _db.Posts.OrderByDescending(p => p.Date).ToList();
            posts.ForEach(p => p.Content = p.Content.Replace("\r\n", "<br />"));

            return View(posts);
        }

        //
        // About
        public ActionResult About()
        {
            var aboutme = new AboutViewModel
            {
                WorkPlaces  = _db.Works.ToList(),
                Schools     = _db.Schools.ToList(),
                Skills      = _db.Skills.ToList(),
                Creations   = _db.Creations.ToList(),
                AboutMe     = _db.Abouts.FirstOrDefault(),
                MyWebsite   = _db.Websites.FirstOrDefault(),
            };

            return View(aboutme);
        }

        //
        // Contact [GET]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //
        // Contact [POST]
        [HttpPost]
        public async Task<ActionResult> ContactMe(ContactMessage msg)
        {
            // get user ip
            var ip      = Request.UserHostAddress;
            var captcha = Request.Form["g-recaptcha-response"];
            var captchaResult = await GetReCaptchaResult(captcha, ip);

            if(captchaResult.success)
            {
                EmailTools emails       = new EmailTools();
                string msgSubject       = "[Website] Someone send you a message";
                string msgBody          = string.Format("{0} has send you a message:\r\n{1}", msg.Email, msg.Content);
                await emails.SendEmail(msgSubject, msgBody);

                ViewBag.MessageResult = "success";
            }
            else
            {
                ViewBag.MessageResult = "error";
            }
           
            return View("Contact");
        }

        //
        // Posts [GET]
        public async Task<List<Post>> GetPosts()
        {
            var posts = _db.Posts.OrderByDescending(p => p.Date).ToList();
            posts.ForEach(p => p.Content = p.Content.Replace("\r\n", "<br />"));

            return posts;
        }
        
        //
        // ClientApp
        public ActionResult ClientApp(string appName)
        {
            ClientAppViewModel result = new ClientAppViewModel();

            if(string.IsNullOrEmpty(appName))
            {
                return null;
            }

            if(!Directory.Exists(Server.MapPath(string.Format(@"~\ClientApps\{0}", appName))))
            {
                return null;
            }

            var items = new Dictionary<string,string>() 
            { 
                { "~/ClientApps/FallingBall/particle.js",       "script" },
                { "~/ClientApps/FallingBall/vector2.js",        "script" },
                { "~/ClientApps/FallingBall/ball.js",           "script" },
                { "~/ClientApps/FallingBall/gameloop.js",       "script" },
                { "~/ClientApps/FallingBall/main.js",           "script" },
                { "~/ClientApps/FallingBall/style.css",    "stylesheet"},
                { "~/ClientApps/FallingBall/index.html",        "html" },
            };
            result.ClientFiles = items;

            return View(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _db != null)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }

        //
        // Helper functions
        private string GetWithBrOverEndOfLine(string content)
        {
            string result = content;

            result.Replace("\r\n", "<br />");

            return result;
        }


        private async Task<CaptchaResponse> GetReCaptchaResult(string response, string ip)
        {
            CaptchaResponse result = null;

            string secret       = ConfigurationManager.AppSettings["RecaptchaSecretKey"].ToString();
            string baseAddress  = ConfigurationManager.AppSettings["BaseAddress"].ToString();
            string uri          = ConfigurationManager.AppSettings["RequestUri"].ToString();
            string absUri       = baseAddress + uri + "?secret=" + secret + "&response=" + response;

            result = await new WebTools().ServiceCall<CaptchaResponse>(absUri);
            return result;
        }

        
    }
}