using HeathProject.Models;
using HeathProject.Repository.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Admin
{
    public class AdminService : IAdminService
    {
        public IAdminRepo adminRepo;
        public AdminService(IAdminRepo adminRepo)
        {
            this.adminRepo = adminRepo; 
        }
        public bool DeletePost(int postId)
        {
            return adminRepo.DeletePost(postId);
        }

        public List<Post> GetAllPost()
        {
            return adminRepo.GetAllPost();
        }
    }
}
