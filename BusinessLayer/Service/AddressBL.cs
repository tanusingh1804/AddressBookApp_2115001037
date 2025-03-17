using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class AddressBL : IAddressBookBL
    {
        private readonly IAddressRL _addressBookRL;

        public AddressBL(IAddressRL addressBookRL)
        {
            _addressBookRL = addressBookRL;
        }

        public List<AddressEntity> GetAllContacts()
        {
            return _addressBookRL.GetAllContacts();
        }

        public AddressEntity GetContactById(int id)
        {
            return _addressBookRL.GetContactById(id);
        }

        public AddressEntity AddContact(AddressEntity contact)
        {
            if (string.IsNullOrEmpty(contact.Name) || string.IsNullOrEmpty(contact.Address))
            {
                throw new ArgumentException("Name and Address cannot be empty.");
            }
            return _addressBookRL.AddContact(contact);
        }

        public AddressEntity UpdateContact(int id, AddressEntity contact)
        {
            var existingContact = _addressBookRL.GetContactById(id);
            if (existingContact == null)
            {
                return null; // Not found
            }
            return _addressBookRL.UpdateContact(id, contact);
        }

        public bool DeleteContact(int id)
        {
            return _addressBookRL.DeleteContact(id);
        }
    }
}
