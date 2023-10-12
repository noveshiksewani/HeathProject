using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.Posts
{
    public interface IPostRepo
    {
        List<Post> SearchByUserName(string userName);
        bool InsertPost(Post post);
        List<Post> GetAllPosts();
        Post GetPost(int postId);
        bool DeletePost(int postId);
    }
}
