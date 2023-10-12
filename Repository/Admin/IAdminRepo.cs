using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.Admin
{
    public interface IAdminRepo
    {
        List<Post> GetAllPost();
        bool DeletePost(int postId);
    }
}
