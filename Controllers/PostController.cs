using HeathProject.Models;
using HeathProject.Service.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeathProject.Controllers
{
    //Get All Post, Upload Image, Add Post, Delete Post, Get Post By Id
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        //Upload Image
        [Authorize(Roles = Roles.User)]
        [HttpPost("uploadFile")]
        public IActionResult Uploadfile(IFormFile file)
        {

            string newFileName = null;
            if (file != null)
            {
                var test = HttpContext.Request.Form;

                var img = file;
                var name = file.FileName;


                string ext = Path.GetExtension(img.FileName);
                string fileName = Path.GetFileNameWithoutExtension(img.FileName);

                newFileName = fileName + DateTime.Now.ToString("yymmssff") + ext;
                string dir = Directory.GetCurrentDirectory();
                dir = dir + "\\wwwroot\\images";

                using (FileStream stream = new FileStream(Path.Combine(dir, newFileName), FileMode.Create))
                {
                    img.CopyTo(stream);

                }
            }
            return Ok(new { newFileName });
        }
        //[Authorize(Roles = Roles.User)]
        // GET: api/<PostController>
        [HttpGet]
        public IEnumerable<Post> GetAllPosts()
        {
            return postService.GetAllPosts();
        }

       // [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        // GET api/<PostController>/5

        [HttpGet("{postId}")]
        public Post GetPost(int postId)
        {
            return postService.GetPost(postId);
        }
        [Authorize(Roles = Roles.User)]

        [HttpPost]
        public IActionResult Post(Post post)
        {
            try
            {
                int userId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
                post.UserId = userId;
                postService.InsertPost(post);
                return Ok(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }
       // [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        // DELETE api/<PostController>/5
        [HttpDelete("{postId}")]
        public IActionResult DeletePost(int postId)
        {
            try
            {
                postService.DeletePost(postId);
                return Ok(true);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("UserName/{userName}")]
        public IActionResult SearchByName(string userName)
        {
            try
            {
                
                return Ok(postService.SearchByUserName(userName));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
