using AutoMapper;
using BusinessLayer.Interface;
using BusinessLayer.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace Controllers
{
    [Route("api/AddressBook")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookBL _addressBookBL;
        private readonly IMapper _mapper;
        private readonly IValidator<AddressBookDTO> _validator;

        public AddressBookController(IAddressBookBL addressBookBL, IMapper mapper, IValidator<AddressBookDTO> validator)
        {
            _addressBookBL = addressBookBL;
            _mapper = mapper;
            _validator = validator;
        }

        //  Get All Contacts
        [HttpGet("GetAllContacts")]
        public IActionResult GetAllContacts()
        {
            var contacts = _addressBookBL.GetAllContacts();
            var contactDTOs = _mapper.Map<List<AddressBookDTO>>(contacts);
            return Ok(contactDTOs);
        }

        // Get Contact By ID
        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _addressBookBL.GetContactById(id);
            if (contact == null)
            {
                return NotFound(new { Message = "Contact not found!" });
            }

            var contactDTO = _mapper.Map<AddressBookDTO>(contact);
            return Ok(contactDTO);
        }

        // Add New Contact (Fixed Route)
        [HttpPost("AddContact")]
        public IActionResult AddContact([FromBody] AddressBookDTO contactDTO)
        {
            var validationResult = _validator.Validate(contactDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var contactEntity = _mapper.Map<AddressEntity>(contactDTO);
            var addedContact = _addressBookBL.AddContact(contactEntity);
            var addedContactDTO = _mapper.Map<AddressBookDTO>(addedContact);

            return CreatedAtAction(nameof(GetContactById), new { id = addedContact.Id }, addedContactDTO);
        }

        // Update Contact
        [HttpPut("UpdateContact/{id}")]
        public IActionResult UpdateContact(int id, [FromBody] AddressBookDTO contactDTO)
        {
            var validationResult = _validator.Validate(contactDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var existingContact = _addressBookBL.GetContactById(id);
            if (existingContact == null)
            {
                return NotFound(new { Message = "Contact not found!" });
            }

            var contactEntity = _mapper.Map<AddressEntity>(contactDTO);
            var updatedContact = _addressBookBL.UpdateContact(id, contactEntity);
            var updatedContactDTO = _mapper.Map<AddressBookDTO>(updatedContact);

            return Ok(updatedContactDTO);
        }

        // Delete Contact
        [HttpDelete("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var existingContact = _addressBookBL.GetContactById(id);
            if (existingContact == null)
            {
                return NotFound(new { Message = "Contact not found!" });
            }

            bool isDeleted = _addressBookBL.DeleteContact(id);
            if (!isDeleted)
            {
                return StatusCode(500, new { Message = "Error deleting contact!" });
            }

            return NoContent();
        }
    }
}
