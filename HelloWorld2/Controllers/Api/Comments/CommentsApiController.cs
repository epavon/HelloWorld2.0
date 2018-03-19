using HelloWorld2.Data;
using HelloWorld2.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace HelloWorld2.Controllers.Api.Comments
{
    [AllowAnonymous]
    [RoutePrefix("api/comments")]
    public class CommentsApiController : ApiController
    {
        private HelloWorldDb db = new HelloWorldDb();

        [HttpGet]
        [Route("getall")]
        public async Task<List<Comment>> GetComments()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{postId}/add")]
        public async Task<JsonResult<Comment>> AddComment(int postId, Comment comment)
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

            comment.Post = null; // avoid circular reference
            return Json(comment);
        }
    }
}