using Pulse.Contacts.Domain.Entities;

namespace Pulse.Contacts.Application.DTOs;

public class ContactDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new();
    public int EngagementScore { get; set; }

    public static ContactDto FromContact(Contact contact)
    {
        return new ContactDto
        {
            Id = contact.Id,
            Name = contact.Name,
            Phone = contact.Phone,
            Email = contact.Email.Value,
            Status = contact.Status.ToString(),
            EngagementScore = contact.EngagementScore,
            Tags = contact.Tags,
        };
    }
}
