﻿using Data.Entities;

namespace labolatorium_3___App.Models
{
    public class MemoryContactService : IContactService
    {
        IDateTimeProvidercs _timeProvider;

        public MemoryContactService(IDateTimeProvidercs timeProvider)
        {
            _timeProvider = timeProvider;
        }

        private Dictionary<int, Contact> _items = new Dictionary<int, Contact>();
        public int Add(Contact item)
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

        public List<Contact> FindAll()
        {
            return _items.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _items[id];
        }

        public void Update(Contact item)
        {
            _items[item.Id] = item;
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            throw new NotImplementedException();
        }
    }
}
