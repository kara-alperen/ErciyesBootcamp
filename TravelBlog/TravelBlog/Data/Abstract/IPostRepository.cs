using TravelBlog.Entitiy;

namespace TravelBlog.Data.Abstract
{
    public interface IPostRepository{
        IQueryable<Post> Posts {get;}
        void CreatePost(Post post);
        void EditPost(Post post);
    }

    
}