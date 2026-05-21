using MediatR;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Application.Commands.DeleteContact;

public class DeleteContactHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly IContactRepository _contactRepository;

    public DeleteContactHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task Handle(DeleteContactCommand command, CancellationToken cancellationToken)
    {
        await _contactRepository.Remove(command.ContactId);
    }
}
