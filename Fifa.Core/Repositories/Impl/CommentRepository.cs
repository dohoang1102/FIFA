using System.Collections.Generic;
using System.Data;
using System.Linq;
using Fifa.Core.Models;

namespace Fifa.Core.Repositories.Impl
{
    public class CommentRepository : RepositoryBase, ICommentRepository
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
                UpdateEntity(context, comment);
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
                return Enumerable.ToList(context.Comments);
            }
        }
    }
}
