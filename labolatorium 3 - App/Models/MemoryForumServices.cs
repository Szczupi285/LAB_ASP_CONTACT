namespace labolatorium_3___App.Models
{
    public class MemoryForumService : IForumService
    {
        IDateTimeProvidercs _timeProvider;

        public MemoryForumService(IDateTimeProvidercs timeProvider)
        {
            _timeProvider = timeProvider;
        }

        private Dictionary<int, Forum> _items = new Dictionary<int, Forum>();
        public int Add(Forum item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            _items.Add(item.Id, item);
            item.Created = _timeProvider.CurrentDate();
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Forum> FindAll()
        {
            return _items.Values.ToList();
        }

        public Forum? FindById(int id)
        {
            return _items[id];
        }

        public void Update(Forum item)
        {
            _items[item.Id] = item;
        }
    }
}
