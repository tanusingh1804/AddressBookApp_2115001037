using System.Collections.Generic;
using ModelLayer.Model; 

namespace BusinessLayer.Interface
{
    public interface IAddressBookBL
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        Contact AddContact(Contact contact);
        Contact UpdateContact(int id, Contact contact);
        bool DeleteContact(int id);
    }
}
