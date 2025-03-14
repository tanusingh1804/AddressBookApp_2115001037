using Microsoft.EntityFrameworkCore;
using AddressBookApplication.ModelLayer.Entity;

namespace AddressBookApplication.RepositoryLayer.Context
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options) : base(options) { }

        public virtual DbSet<AddressEntity> Addresses { get; set; }
    }
}
