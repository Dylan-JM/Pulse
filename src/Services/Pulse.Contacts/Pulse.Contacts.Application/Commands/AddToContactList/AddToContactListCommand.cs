using MediatR;

namespace Pulse.Contacts.Application.Commands.AddToContactList;

public class AddToContactListCommand : IRequest
{
    public Guid ContactListId { get; }
    public Guid ContactId { get; }

    public AddToContactListCommand(Guid contactListId, Guid contactId)
    {
        ContactListId = contactListId;
        ContactId = contactId;
    }
}
