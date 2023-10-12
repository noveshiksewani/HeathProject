using HeathProject.Models;
using HeathProject.Repository.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Service.Comments
{
    public class CommentsService : ICommentsService
    {
        public ICommentsRepo commentsRepo;

        public CommentsService(ICommentsRepo commentsRepo)
        {
            this.commentsRepo = commentsRepo;
        }
        public bool AddComments(Comment comment)
        {
            return commentsRepo.AddComments(comment);
        }

        public bool DeleteOwnComment(int Id, int commentId)
        {

            if (commentsRepo.DeleteOwnComment(Id, commentId))
                return true;
            else
                return false;

            
        }
        public List<Comment> GetComments(int postId)
        {
            return commentsRepo.GetComments(postId);
        }
    }
}
