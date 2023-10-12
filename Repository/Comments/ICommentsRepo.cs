using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.Comments
{
    public interface ICommentsRepo
    {
        bool AddComments(Comment comment);

        bool DeleteOwnComment(int Id, int commentId);
        List<Comment> GetComments(int postId);
    }
}
