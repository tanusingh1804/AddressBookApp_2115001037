using System.Collections.Generic;
using AddressBookApplication.ModelLayer.Entity;

namespace AddressBookApplication.RepositoryLayer.Interface
{
    public interface IAddressRL
    {
        bool AddAddress(AddressEntity address);
        List<AddressEntity> GetAllAddresses();
        AddressEntity GetAddressById(int id);
        bool UpdateAddress(int id, AddressEntity updatedAddress);
        bool DeleteAddress(int id);
    }
}
