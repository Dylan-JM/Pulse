using MediatR;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Application.Commands.CreateContactList;

public class CreateContactListHandler : IRequestHandler<CreateContactListCommand, Guid>
{
    private readonly IContactListRepository _repository;

    public CreateContactListHandler(IContactListRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateContactListCommand request,
        CancellationToken cancellationToken
    )
    {
        ContactList newContactList = new ContactList(request.Name);
        await _repository.Add(newContactList);
        return newContactList.Id;
    }
}
