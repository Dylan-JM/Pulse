using MediatR;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Application.Queries.GetAllContacts;

public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<Contact>>
{
    private readonly IContactRepository _contactRepository;

    public GetAllContactsHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<List<Contact>> Handle(
        GetAllContactsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _contactRepository.GetAll();
    }
}
