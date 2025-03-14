using System.Collections.Generic;
using AddressBookApplication.ModelLayer.Entity;

namespace AddressBookApplication.BusinessLayer.Interface
{
    public interface IAddressBL
    {
        bool AddAddress(AddressEntity address);
        List<AddressEntity> GetAllAddresses();
        AddressEntity GetAddressById(int id);
        bool UpdateAddress(int id, AddressEntity address);
        bool DeleteAddress(int id);
    }
}
