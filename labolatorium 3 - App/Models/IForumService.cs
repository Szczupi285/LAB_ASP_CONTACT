namespace labolatorium_3___App.Models
{
    public interface IForumService
    {
        int Add(Forum book);
        void Delete(int id);
        void Update(Forum book);
        List<Forum> FindAll();
        Forum? FindById(int id);
    }
}
