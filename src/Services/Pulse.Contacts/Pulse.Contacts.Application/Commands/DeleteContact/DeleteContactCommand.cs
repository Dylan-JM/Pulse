using MediatR;

namespace Pulse.Contacts.Application.Commands.DeleteContact;

public class DeleteContactCommand : IRequest
{
    public Guid ContactId { get; }

    public DeleteContactCommand(Guid contactId)
    {
        ContactId = contactId;
    }
}
