using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using ModelLayer.Model; 

namespace RepositoryLayer.Context
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options) : base(options) { }

        public DbSet<AddressEntity> Addresses { get; set; } // 

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<RepositoryLayer.Entity.User> Users { get; set; }

    }
}
