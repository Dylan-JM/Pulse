using Pulse.Contacts.Domain.Entities;

namespace Pulse.Contacts.Domain.Repositories;

public interface IContactListRepository
{
    Task<ContactList?> GetById(Guid id);
    Task Add(ContactList contactList);
    Task Remove(Guid id);
    Task Update(ContactList contactList);
}
