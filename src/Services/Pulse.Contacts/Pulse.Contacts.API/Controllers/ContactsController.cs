using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pulse.Contacts.Application.Commands.CreateContact;
using Pulse.Contacts.Application.Commands.DeleteContact;
using Pulse.Contacts.Application.DTOs;
using Pulse.Contacts.Application.Queries.GetAllContacts;
using Pulse.Contacts.Application.Queries.GetContactById;
using Pulse.Contacts.Domain.Entities;

namespace Pulse.Contacts.API.Controllers;

[ApiController]
[Route("api/contacts")]
public class ContactsController : ControllerBase
{
    private readonly ISender _sender;

    public ContactsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<List<ContactDto>> GetAll()
    {
        var contactQuery = new GetAllContactsQuery();
        return await _sender.Send(contactQuery);
    }

    [HttpGet("{id:guid}")]
    public async Task<ContactDto> GetById(Guid id)
    {
        var contactQuery = new GetContactByIdQuery(id);
        return await _sender.Send(contactQuery);
    }

    [HttpPost]
    public async Task CreateContact([FromBody] CreateContactCommand command)
    {
        await _sender.Send(command);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteContact(Guid id)
    {
        var deleteQuery = new DeleteContactCommand(id);
        await _sender.Send(deleteQuery);
    }
}
