using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.Service
{
    public class AddressRL : IAddressRL
    {
        private readonly AddressContext _context;

        public AddressRL(AddressContext context)
        {
            _context = context;
        }

        public List<AddressEntity> GetAllContacts()
        {
            return _context.Addresses.ToList();
        }

        public AddressEntity GetContactById(int id)
        {
            return _context.Addresses.FirstOrDefault(contact => contact.Id == id);
        }

        public AddressEntity AddContact(AddressEntity contact)
        {
            _context.Addresses.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public AddressEntity UpdateContact(int id, AddressEntity contact)
        {
            var existingContact = _context.Addresses.Find(id);
            if (existingContact != null)
            {
                existingContact.Name = contact.Name;
                existingContact.Email = contact.Email;
                existingContact.Address = contact.Address;
                _context.SaveChanges();
            }
            return existingContact;
        }

        public bool DeleteContact(int id)
        {
            var contact = _context.Addresses.Find(id);
            if (contact != null)
            {
                _context.Addresses.Remove(contact);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
