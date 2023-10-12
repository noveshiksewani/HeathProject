using HeathProject.CustomException;
using HeathProject.DbContexts;
using HeathProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.Admin
{
    public class AdminRepo : IAdminRepo
    {
        public testContext healthDbContext;

        public AdminRepo(testContext healthDbContext)
        {
            this.healthDbContext = healthDbContext;
        }
        public bool DeletePost(int postId)
        {
            Post post = new Post();
            post = healthDbContext.Posts.Find(postId);
            if (post != null)
            {
                Comment checkComment = healthDbContext.Comments.Where(comment => comment.PostId == post.PostId).FirstOrDefault();
                if (checkComment != null)
                {
                    List<Comment> listOfComments = healthDbContext.Comments.Where(comment => comment.PostId == post.PostId).ToList();
                    foreach (Comment com in listOfComments)
                    {
                        healthDbContext.Comments.Remove(com);
                        healthDbContext.SaveChanges();
                    }
                }
                healthDbContext.Posts.Remove(post);
                healthDbContext.SaveChanges();
                return true;
            }
            else
                throw new InvalidDataException("Post Not Found");
        }

        public List<Post> GetAllPost()
        {
            List<Post> listOfAllPost = new List<Post>();
            listOfAllPost = healthDbContext.Posts.Include(x => x.Comments).ToList();
            if (listOfAllPost != null)
            {
                return listOfAllPost;
            }
            else
                throw new InvalidDataException("No Post Are Available");
        }
    }
}
