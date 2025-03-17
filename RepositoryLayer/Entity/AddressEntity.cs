using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Entity
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
