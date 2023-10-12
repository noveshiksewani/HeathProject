using HeathProject.DbContexts;
using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.Posts
{
    public class PostRepo : IPostRepo
    {
        public testContext dbContext;

        public PostRepo(testContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Post> SearchByUserName(string userName)
        {
         
          var result=  (from cp in dbContext.Posts
             join p in dbContext.Users on cp.UserId equals p.UserId
             where p.UserName==userName
             select new Post
             {
                 PostId = cp.PostId,
                 ImageUrl = cp.ImageUrl,
                 Description= cp.Description,
                 Timestamp= cp.Timestamp,
                 UserId=p.UserId

             }).ToList();
            return result;
        }

        public bool DeletePost(int postId)
        {
            Post post = dbContext.Posts.Find(postId);
            if (post != null)
            {
                dbContext.Posts.Remove(post);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                throw new InvalidDataException("Post not found!");
            }
        }

        public List<Post> GetAllPosts()
        {
            List<Post> posts = dbContext.Posts.ToList();
            if (posts != null)
            {
                return posts;
            }
            else
            {
                throw new InvalidDataException("No posts were found");
            }
        }

        public Post GetPost(int postId)
        {
            Post post = dbContext.Posts.Find(postId);
            if (post != null)
            {
                return post;
            }
            else
            {
                throw new InvalidDataException("Post not found!");
            }
        }

        public bool InsertPost(Post post)
        {
            if (post != null)
            {
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                throw new InvalidDataException("New post could not be added!");
            }
        }

    }
}
