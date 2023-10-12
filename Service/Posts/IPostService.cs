using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Posts
{
    public interface IPostService
    {
        List<Post> SearchByUserName(string userName);
        bool InsertPost(Post posts);
        List<Post> GetAllPosts();
        Post GetPost(int postId);
        bool DeletePost(int postId);
    }
}
