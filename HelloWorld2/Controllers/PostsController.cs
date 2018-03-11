using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelloWorld2.Models;
using HelloWorld2.Data;
using HelloWorld2.Model;
using System.IO;

namespace HelloWorld2.Controllers
{
    [AllowAnonymous]
    public class PostsController : Controller
    {
        private HelloWorldDb db = new HelloWorldDb();

        // GET: Posts
        public async Task<ActionResult> Index()
        {
            return View(await db.Posts.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
           
            return View(post);
        }


        // POST: Posts/AddComment
        [HttpPost]
        public async Task<ActionResult> AddComment([Bind(Include = "Content,Author,PostId")]Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Date = DateTime.Today;
                Post post = await db.Posts.FindAsync(comment.PostId);
                if (post == null)
                {
                    return HttpNotFound();
                }

                post.Comments.Add(comment);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Details", new  { id = comment.PostId });
        }


        
    }
}
