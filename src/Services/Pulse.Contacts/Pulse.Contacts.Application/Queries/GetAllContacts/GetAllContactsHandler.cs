using MediatR;
using Pulse.Contacts.Application.DTOs;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Application.Queries.GetAllContacts;

public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<ContactDto>>
{
    private readonly IContactRepository _contactRepository;

    public GetAllContactsHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<List<ContactDto>> Handle(
        GetAllContactsQuery request,
        CancellationToken cancellationToken
    )
    {
        var contacts = await _contactRepository.GetAll();
        return contacts.Select(ContactDto.FromContact).ToList();
    }
}
