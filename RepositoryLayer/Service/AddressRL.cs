using AddressBookApplication.RepositoryLayer.Context;
using AddressBookApplication.RepositoryLayer.Interface;

namespace AddressBookApplication.RepositoryLayer.Service
{
    public class AddressRL : IAddressRL
    {
        private readonly AddressContext _context;

        public AddressRL(AddressContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
