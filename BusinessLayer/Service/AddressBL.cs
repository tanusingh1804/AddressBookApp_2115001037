using BusinessLayer.Interface;
using ModelLayer.Model; 
using RepositoryLayer.Context;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Service
{
    public class AddressBL : IAddressBookBL
    {
        private readonly AddressContext _context; 

        public AddressBL(AddressContext context) 
        {
            _context = context;
        }

        public List<Contact> GetAllContacts() => _context.Contacts.ToList(); 

        public Contact GetContactById(int id) => _context.Contacts.FirstOrDefault(a => a.Id == id); 

        public Contact AddContact(Contact contact)
        {
            _context.Contacts.Add(contact); 
            _context.SaveChanges();
            return contact;
        }

        public Contact UpdateContact(int id, Contact contact)
        {
            var existingContact = _context.Contacts.FirstOrDefault(a => a.Id == id);
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
            var contact = _context.Contacts.FirstOrDefault(a => a.Id == id);
            if (contact == null) return false;

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return true;
        }
    }
}
