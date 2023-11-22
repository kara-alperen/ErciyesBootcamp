using TravelBlog.Entitiy;

namespace TravelBlog.Data.Abstract
{
    public interface ICommentRepository{
        IQueryable<Comment> Comments {get;}
        void CreatePost(Comment comment);
    }

    
}