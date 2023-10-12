using HeathProject.CustomException;
using HeathProject.DbContexts;
using HeathProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.Repository.Comments
{
    public class CommentsRepo : ICommentsRepo
    {
        public testContext db;

        public CommentsRepo(testContext db)
        {
            this.db = db;
                
        }

        public bool AddComments(Comment comment)
        {
            if (comment != null)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return true;
            }
            else
                throw new InvalidDataException("Comment Details is not Valid");

        }

        public bool DeleteOwnComment(int userId, int commentId)
        {
            Comment comments = db.Comments.Where(x => x.CommentId == commentId && x.UserId == userId).FirstOrDefault();

            if(comments != null)
            {
                db.Comments.Remove(comments);
                db.SaveChanges();
                return true;

            }
            else
                throw new InvalidDataException("Comment Id Not Found");
        }
        public List<Comment> GetComments(int postId)
        {
            List<Comment> comments = db.Comments.Where(x => x.PostId == postId).ToList();
            return comments;
        }


    }
}
