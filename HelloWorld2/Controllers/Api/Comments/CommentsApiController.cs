using HelloWorld2.Data;
using HelloWorld2.Model;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelloWorld2.Controllers.Api.Comments
{
    [Route("api/Comments")]
    public class CommentsApiController : Controller
    {
        private HelloWorldDb db = new HelloWorldDb();

        [HttpPost]
        public async Task<JsonResult> AddComment([Bind(Include = "Content,Author,PostId")]Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Date = DateTime.Today;
                Post post = await db.Posts.FindAsync(comment.PostId);
                if (post == null)
                {
                    return null;
                }

                post.Comments.Add(comment);
                await db.SaveChangesAsync();
            }
            return Json(comment);
        }
    }
}