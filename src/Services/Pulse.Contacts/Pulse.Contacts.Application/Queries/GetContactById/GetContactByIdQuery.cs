using MediatR;
using Pulse.Contacts.Application.DTOs;

namespace Pulse.Contacts.Application.Queries.GetContactById;

public class GetContactByIdQuery : IRequest<ContactDto>
{
    public Guid Id { get; set; }

    public GetContactByIdQuery(Guid contactId)
    {
        Id = contactId;
    }
}
