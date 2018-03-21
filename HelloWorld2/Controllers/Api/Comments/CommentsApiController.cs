using HelloWorld2.Data;
using HelloWorld2.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace HelloWorld2.Controllers.Api.Comments
{
    [AllowAnonymous]
    [RoutePrefix("api/posts")]
    public class CommentsApiController : ApiController
    {
        private HelloWorldDb db = new HelloWorldDb();

        [HttpGet]
        [Route("{postid}/comments")]
        public async Task<IHttpActionResult> GetComments(int postid)
        {
            Post post = await db.Posts.FindAsync(postid);
            if(post == null)
            {
                return NotFound();
            }

            return Ok(post.Comments);
        }

        [HttpPost]
        [ResponseType(typeof(Comment))]
        [Route("{postid}/add")]
        public async Task<IHttpActionResult> AddComment(int postid, Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Date = DateTime.Today;
                Post post = await db.Posts.FindAsync(postid);
                if (post == null)
                {
                    return NotFound() ;
                }

                post.Comments.Add(comment);
                await db.SaveChangesAsync();

                comment.Post = null; // avoid circular reference
                return Ok(comment);
            }

            return BadRequest();
        }
    }
}