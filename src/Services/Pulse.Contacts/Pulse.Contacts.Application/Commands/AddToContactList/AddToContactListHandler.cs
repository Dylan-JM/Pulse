using MediatR;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Application.Commands.AddToContactList;

public class AddToContactListHandler : IRequestHandler<AddToContactListCommand>
{
    private readonly IContactListRepository _repository;

    public AddToContactListHandler(IContactListRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(AddToContactListCommand request, CancellationToken cancellationToken)
    {
        ContactList? contactList = await _repository.GetById(request.ContactListId);
        contactList?.AddContact(request.ContactId);
        if (contactList != null)
            await _repository.Update(contactList);
    }
}
