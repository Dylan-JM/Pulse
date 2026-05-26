using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pulse.Contacts.Application.Commands.AddToContactList;
using Pulse.Contacts.Application.Commands.CreateContactList;
using Pulse.Contacts.Application.Commands.DeleteContactList;

namespace Pulse.Contacts.API.Controllers;

[ApiController]
[Route("api/contactlists")]
public class ContactListsController : ControllerBase
{
    private readonly ISender _sender;

    public ContactListsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<Guid> CreateContactList([FromBody] CreateContactListCommand command)
    {
        return await _sender.Send(command);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteContactList(Guid id)
    {
        var deleteQuery = new DeleteContactListCommand(id);
        await _sender.Send(deleteQuery);
    }

    [HttpPost("{id:guid}/contacts")]
    public async Task AddContactList([FromBody] AddToContactListCommand command, Guid id)
    {
        await _sender.Send(command);
    }
}
