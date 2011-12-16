using System.Collections.Generic;
using System.Data;
using System.Linq;

using Fifa.Models;

namespace Fifa.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public void DeleteComment(int id)
        {
            var comment = GetComment(id);
            using (var context = new MainContext())
            {
                context.Entry(comment).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveComment(Comment comment)
        {
            using (var context = new MainContext())
            {
                Repository.UpdateEntity(context, comment);
                context.SaveChanges();
            }
        }

        public Comment GetComment(int id)
        {
            using (var context = new MainContext())
            {
                return context.Comments.Find(id);
            }
        }

        public IEnumerable<Comment> GetAllComments()
        {
            using (var context = new MainContext())
            {
                return context.Comments.ToList();
            }
        }
    }
}
