using AutoMapper;
using BusinessLayer.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace Controllers
{
    [Route("api/addressbook")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookBL _addressBookService;
        private readonly IMapper _mapper;
        private readonly IValidator<Contact> _validator;

        public AddressBookController(IAddressBookBL addressBookService, IMapper mapper, IValidator<Contact> validator)
        {
            _addressBookService = addressBookService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = _addressBookService.GetAllContacts();
            var contactDTOs = _mapper.Map<List<Contact>>(contacts);
            return Ok(contactDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _addressBookService.GetContactById(id);
            if (contact == null) return NotFound(new { Message = "Contact not found!" });

            var contactDTO = _mapper.Map<Contact>(contact);
            return Ok(contactDTO);
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] Contact contactDTO)
        {
            var validationResult = _validator.Validate(contactDTO);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var contactEntity = _mapper.Map<Contact>(contactDTO);
            var addedContact = _addressBookService.AddContact(contactEntity);
            var addedContactDTO = _mapper.Map<Contact>(addedContact);

            return CreatedAtAction(nameof(GetContactById), new { id = addedContact.Id }, addedContactDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] Contact contactDTO)
        {
            var validationResult = _validator.Validate(contactDTO);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var existingContact = _addressBookService.GetContactById(id);
            if (existingContact == null) return NotFound(new { Message = "Contact not found!" });

            var contactEntity = _mapper.Map<Contact>(contactDTO);
            var updatedContact = _addressBookService.UpdateContact(id, contactEntity);
            var updatedContactDTO = _mapper.Map<Contact>(updatedContact);

            return Ok(updatedContactDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var existingContact = _addressBookService.GetContactById(id);
            if (existingContact == null) return NotFound(new { Message = "Contact not found!" });

            bool isDeleted = _addressBookService.DeleteContact(id);
            if (!isDeleted) return StatusCode(500, new { Message = "Error deleting contact!" });

            return NoContent();
        }
    }
}
