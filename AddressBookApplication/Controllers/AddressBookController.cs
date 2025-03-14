using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AddressBookApplication.BusinessLayer.Interface;
using AddressBookApplication.ModelLayer.Entity;

namespace AddressBookApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL _addressBL;

        public AddressController(IAddressBL addressBL)
        {
            _addressBL = addressBL;
        }

        [HttpPost("AddAddress")]
        public IActionResult AddAddress([FromBody] AddressEntity address)
        {
            bool result = _addressBL.AddAddress(address);
            return Ok(new { success = result });
        }

        [HttpGet("GetAllAddresses")]
        public IActionResult GetAllAddresses()
        {
            var result = _addressBL.GetAllAddresses();
            return Ok(new { success = result });
        }

        [HttpGet("GetAddressById/{id}")]
        public IActionResult GetAddressById(int id)
        {
            var result = _addressBL.GetAddressById(id);
            return Ok(new { success = result });
        }

        [HttpPut("UpdateAddress/{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] AddressEntity updatedAddress)
        {
            var result = _addressBL.UpdateAddress(id, updatedAddress);
            return Ok(new { success = result });
        }

        [HttpDelete("DeleteAddress/{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var result = _addressBL.DeleteAddress(id);
            return Ok(new { success = result });
        }
    }
}
