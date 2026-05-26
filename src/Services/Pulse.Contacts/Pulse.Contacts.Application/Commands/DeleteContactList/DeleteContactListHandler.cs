using MediatR;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Application.Commands.DeleteContactList;

public class DeleteContactListHandler : IRequestHandler<DeleteContactListCommand>
{
    private readonly IContactListRepository _contactListRepository;

    public DeleteContactListHandler(IContactListRepository contactListRepository)
    {
        _contactListRepository = contactListRepository;
    }

    public async Task Handle(DeleteContactListCommand command, CancellationToken cancellationToken)
    {
        await _contactListRepository.Remove(command.ContactListId);
    }
}
