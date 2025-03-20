using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.Service
{
    public class AddressRL : IAddressRL
    {
        private readonly AddressContext _context; // Use correct DbContext

        public AddressRL(AddressContext context)
        {
            _context = context;
        }

        public List<AddressEntity> GetAllContacts() => _context.Addresses.ToList(); //  Fetch all contacts

        public AddressEntity GetContactById(int id) => _context.Addresses.FirstOrDefault(a => a.Id == id); // ✅Find by ID

        public AddressEntity AddContact(AddressEntity contact)
        {
            _context.Addresses.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public AddressEntity UpdateContact(int id, AddressEntity contact)
        {
            var existingContact = _context.Addresses.FirstOrDefault(a => a.Id == id);
            if (existingContact == null) return null;

            existingContact.Name = contact.Name;
            existingContact.Address = contact.Address;
            existingContact.Email = contact.Email;
            existingContact.PhoneNumber = contact.PhoneNumber;

            _context.SaveChanges();
            return existingContact;
        }

        public bool DeleteContact(int id)
        {
            var contact = _context.Addresses.FirstOrDefault(a => a.Id == id);
            if (contact == null) return false;

            _context.Addresses.Remove(contact);
            _context.SaveChanges();
            return true;
        }
    }
}
