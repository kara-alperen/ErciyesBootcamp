using TravelBlog.Entitiy;

namespace TravelBlog.Data.Abstract
{
    public interface IUserRepository{
        IQueryable<User> Users {get;}
        void CreateUser(User user);
    }

    
}