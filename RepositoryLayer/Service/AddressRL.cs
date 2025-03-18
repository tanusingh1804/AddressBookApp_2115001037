using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.Service
{
    public class AddressRL : IAddressRL
    {
        private static List<AddressEntity> addressBook = new List<AddressEntity>();

        public List<AddressEntity> GetAllContacts() => addressBook;

        public AddressEntity GetContactById(int id) => addressBook.FirstOrDefault(c => c.Id == id);

        public AddressEntity AddContact(AddressEntity contact)
        {
            contact.Id = addressBook.Count + 1;
            addressBook.Add(contact);
            return contact;
        }

        public AddressEntity UpdateContact(int id, AddressEntity contact)
        {
            var existingContact = GetContactById(id);
            if (existingContact == null) return null;

            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.PhoneNumber = contact.PhoneNumber;
            return existingContact;
        }

        public bool DeleteContact(int id)
        {
            var contact = GetContactById(id);
            if (contact == null) return false;

            addressBook.Remove(contact);
            return true;
        }
    }
}
