using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Comments
{
   public interface ICommentsService
    {
        bool AddComments(Comment comment);

        bool DeleteOwnComment(int Id, int commentId);
        List<Comment> GetComments(int postId);
    }
}
