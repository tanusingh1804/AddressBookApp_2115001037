using Microsoft.AspNetCore.Mvc;
using AddressBookApplication.RepositoryLayer.Interface;

namespace AddressBookApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressRL _addressRL;

        public AddressBookController(IAddressRL addressRL)
        {
            _addressRL = addressRL ?? throw new ArgumentNullException(nameof(addressRL));
        }
    }
}
