using HeathProject.DbContexts;
using HeathProject.Models;
using HeathProject.Service.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeathProject.Controllers
{
    //Add Comment, Get Comment, Delete Comment
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        public ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }
        //Add Comment
        [Authorize(Roles = Roles.User)]
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            try
            {
                comment.UserId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
                commentsService.AddComments(comment);
                return Ok(HttpStatusCode.Created);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        //Get Comments by postId
        //[Authorize(Roles = Roles.User + "," + Roles.Admin)]
        [HttpGet("{postId}")]
        public IActionResult GetComments(int postId)
        {
            try
            {
                List<Comment> comments = commentsService.GetComments(postId);
                return Ok(comments);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        //Delete Comment by CommentId
        [Authorize(Roles = Roles.User+","+Roles.Admin)]
        [HttpDelete("deletecomment/{commentId}")]

        public IActionResult DeleteComment(int commentId)
        {
            try
            {
                int userId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
               
                if (commentsService.DeleteOwnComment(userId, commentId))
                {
                    return Ok(HttpStatusCode.OK);
                }
                return Ok(HttpStatusCode.BadRequest);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }



    }
}
