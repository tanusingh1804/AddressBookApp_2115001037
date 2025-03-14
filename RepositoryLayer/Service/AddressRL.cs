using System.Collections.Generic;
using System.Linq;
using AddressBookApplication.RepositoryLayer.Context;
using AddressBookApplication.ModelLayer.Entity;
using AddressBookApplication.RepositoryLayer.Interface;

namespace AddressBookApplication.RepositoryLayer.Service
{
    public class AddressRL : IAddressRL
    {
        private readonly AddressContext _context;

        public AddressRL(AddressContext context)
        {
            _context = context;
        }

        public bool AddAddress(AddressEntity address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return true;
        }

        public List<AddressEntity> GetAllAddresses()
        {
            return _context.Addresses.ToList();
        }

        public AddressEntity GetAddressById(int id)
        {
            return _context.Addresses.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateAddress(int id, AddressEntity updatedAddress)
        {
            var existingAddress = _context.Addresses.Find(id);
            if (existingAddress != null)
            {
                existingAddress.Name = updatedAddress.Name;
                existingAddress.Email = updatedAddress.Email;
                existingAddress.Phone = updatedAddress.Phone;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAddress(int id)
        {
            var address = _context.Addresses.Find(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
