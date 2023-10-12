using HeathProject.Models;
using HeathProject.Repository.Posts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Posts
{
    public class PostService : IPostService
    {
        public IPostRepo postRepo;

        public PostService(IPostRepo postRepo)
        {
            this.postRepo = postRepo;
        }

        public bool DeletePost(int postId)
        {
            return postRepo.DeletePost(postId);
        }

        public List<Post> GetAllPosts()
        {
            return postRepo.GetAllPosts();
        }

        public Post GetPost(int postId)
        {
            return postRepo.GetPost(postId);
        }

        public bool InsertPost(Post post)
        {
            return postRepo.InsertPost(post);
        }

        public List<Post> SearchByUserName(string userName)
        {
            return postRepo.SearchByUserName(userName);
        }
    }
}
