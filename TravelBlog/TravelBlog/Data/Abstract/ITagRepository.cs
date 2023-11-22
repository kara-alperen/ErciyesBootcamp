using TravelBlog.Entitiy;

namespace TravelBlog.Data.Abstract
{
    public interface ITagRepository{
        IQueryable<Tag> Tags {get;}

        void CreateTag(Tag tag);
    }
}