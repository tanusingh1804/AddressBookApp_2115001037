using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IAddressRL
    {
        List<AddressEntity> GetAllContacts(); // ✅ Fetch all contacts
        AddressEntity GetContactById(int id); // ✅ Get contact by ID
        AddressEntity AddContact(AddressEntity contact); // ✅ Add contact
        AddressEntity UpdateContact(int id, AddressEntity contact); // ✅ Update contact
        bool DeleteContact(int id); // ✅ Delete contact
    }
}
