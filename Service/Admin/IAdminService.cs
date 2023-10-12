using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Admin
{
    public interface IAdminService
    {
        List<Post> GetAllPost();
        bool DeletePost(int postId);
    }
}
