using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System.Collections.Generic;

namespace BusinessLayer.Service
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressRL _addressRL;

        public AddressBookService(IAddressRL addressRL)
        {
            _addressRL = addressRL;
        }

        public List<AddressEntity> GetAllContacts() => _addressRL.GetAllContacts();

        public AddressEntity GetContactById(int id) => _addressRL.GetContactById(id);

        public AddressEntity AddContact(AddressEntity contact) => _addressRL.AddContact(contact);

        public AddressEntity UpdateContact(int id, AddressEntity contact) => _addressRL.UpdateContact(id, contact);

        public bool DeleteContact(int id) => _addressRL.DeleteContact(id);
    }
}
