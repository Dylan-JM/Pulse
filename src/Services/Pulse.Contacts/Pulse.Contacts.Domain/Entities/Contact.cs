using Pulse.Contacts.Domain.Enums;
using Pulse.Contacts.Domain.ValueObjects;

namespace Pulse.Contacts.Domain.Entities;

public class Contact
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public string? Phone { get; private set; }
    public List<string> Tags { get; private set; }
    public ContactStatus Status { get; private set; }
    public Email Email { get; }

    public int EngagementScore { get; private set; }

    public Contact(string name, Email email, string phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Phone = phone;
        Tags = new List<string>();
        Status = ContactStatus.Active;
        EngagementScore = 0;
    }
}
