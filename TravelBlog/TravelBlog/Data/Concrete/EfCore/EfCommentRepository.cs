using TravelBlog.Data.Abstract;
using TravelBlog.Data.Concrete.EfCore;
using TravelBlog.Entitiy;

namespace TravelBlog.Data.Concrete
{
    public class EfCommentRepository : ICommentRepository
    {
        private BlogContext _context;
        public EfCommentRepository(BlogContext context){
            _context = context;
        }
        public IQueryable<Comment> Comments => _context.Comments;

        
        public void CreatePost(Comment comment)
        {
             _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
