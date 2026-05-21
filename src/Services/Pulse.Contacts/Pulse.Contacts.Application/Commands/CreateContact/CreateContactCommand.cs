using MediatR;

namespace Pulse.Contacts.Application.Commands.CreateContact;

public class CreateContactCommand : IRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public CreateContactCommand(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}
