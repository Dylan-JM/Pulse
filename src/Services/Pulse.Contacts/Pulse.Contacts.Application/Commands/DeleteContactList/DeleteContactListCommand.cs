using MediatR;

namespace Pulse.Contacts.Application.Commands.DeleteContactList;

public class DeleteContactListCommand : IRequest
{
    public Guid ContactListId { get; }

    public DeleteContactListCommand(Guid contactListId)
    {
        ContactListId = contactListId;
    }
}
