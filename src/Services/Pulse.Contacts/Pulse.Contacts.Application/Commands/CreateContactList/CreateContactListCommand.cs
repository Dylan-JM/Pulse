using MediatR;

namespace Pulse.Contacts.Application.Commands.CreateContactList;

public class CreateContactListCommand : IRequest<Guid>
{
    public string Name { get; set; }

    public CreateContactListCommand(string name)
    {
        Name = name;
    }
}
