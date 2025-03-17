using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IAddressBookBL
    {
        List<AddressEntity> GetAllContacts();
        AddressEntity GetContactById(int id);
        AddressEntity AddContact(AddressEntity contact);
        AddressEntity UpdateContact(int id, AddressEntity contact);
        bool DeleteContact(int id);
    }
}
