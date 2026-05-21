using MediatR;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Application.Queries.GetContactById;

public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, Contact?>
{
    private readonly IContactRepository _contactRepository;

    public GetContactByIdHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<Contact?> Handle(
        GetContactByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        return await _contactRepository.GetById(query.Id);
    }
}
