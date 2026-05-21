using MediatR;
using Pulse.Contacts.Domain.Entities;

namespace Pulse.Contacts.Application.Queries.GetContactById;

public class GetContactByIdQuery : IRequest<Contact>
{
    public Guid Id { get; set; }

    public GetContactByIdQuery(Guid contactId)
    {
        Id = contactId;
    }
}
