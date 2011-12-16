using System.Collections.Generic;
using System.Linq;

namespace Fifa.Core.Repositories.Impl
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
                return Enumerable.ToList(context.Comments);
            }
        }
    }
}
