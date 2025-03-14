using System.Collections.Generic;
using AddressBookApplication.BusinessLayer.Interface;
using AddressBookApplication.ModelLayer.Entity;
using AddressBookApplication.RepositoryLayer.Interface;

namespace AddressBookApplication.BusinessLayer.Service
{
    public class AddressBL : IAddressBL
    {
        private readonly IAddressRL _addressRL;

        public AddressBL(IAddressRL addressRL)
        {
            _addressRL = addressRL;
        }

        public bool AddAddress(AddressEntity address)
        {
            return _addressRL.AddAddress(address);
        }

        public List<AddressEntity> GetAllAddresses()
        {
            return _addressRL.GetAllAddresses();
        }

        public AddressEntity GetAddressById(int id)
        {
            return _addressRL.GetAddressById(id);
        }

        public bool UpdateAddress(int id, AddressEntity updatedAddress)
        {
            return _addressRL.UpdateAddress(id, updatedAddress);
        }

        public bool DeleteAddress(int id)
        {
            return _addressRL.DeleteAddress(id);
        }
    }
}
