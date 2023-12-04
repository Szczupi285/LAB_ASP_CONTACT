using Data.Entities;

namespace labolatorium_3___App.Models
{
    public class ContactMapper
    {
        public static ContactEntity ToEntity(Contact model)
        {
            return new ContactEntity 
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Birth = model.Birth,
                OrganizationId = model.OrganizationId,

            };
        }

        public static Contact FromEntity(ContactEntity entity) 
        {
            return new Contact()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Birth = entity.Birth,
                OrganizationId = entity.OrganizationId,
            };
        }

        public static List<Contact> FromEntityList(List<ContactEntity> entities)
        {

            List<Contact> contacts = new List<Contact>();
            foreach(var entity in entities)
            {
                Contact contact = new Contact()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    Phone = entity.Phone,
                    Birth = entity.Birth,
                    OrganizationId = entity.OrganizationId,
                };
                contacts.Add(contact);
            }

            return contacts;
        }
    }
}
