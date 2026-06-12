using MediatR;
using Pulse.Contacts.Application.DTOs;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Application.Queries.GetContactById;

public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ContactDto?>
{
    private readonly IContactRepository _contactRepository;

    public GetContactByIdHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<ContactDto?> Handle(
        GetContactByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        var contact = await _contactRepository.GetById(query.Id);
        return contact is null ? null : ContactDto.FromContact(contact);
    }
}
