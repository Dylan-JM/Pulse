namespace Pulse.Contacts.Domain.Entities;

public class ContactList
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public List<Guid> ContactIds { get; private set; }

    public ContactList(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        ContactIds = new List<Guid>();
    }

    public void AddContact(Guid contactId)
    {
        if (ContactIds.Contains(contactId))
            return;
        ContactIds.Add(contactId);
    }

    public void RemoveContact(Guid contactId)
    {
        ContactIds.Remove(contactId);
    }
}
