using MediatR;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;
using Pulse.Contacts.Domain.ValueObjects;

namespace Pulse.Contacts.Application.Commands.CreateContact;

public class CreateContactHandler : IRequestHandler<CreateContactCommand>
{
    private readonly IContactRepository _contactRepository;

    public CreateContactHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task Handle(CreateContactCommand command, CancellationToken cancellationToken)
    {
        Contact newContact = new Contact(command.Name, Email.Create(command.Email), command.Phone);
        await _contactRepository.Add(newContact);
    }
}
