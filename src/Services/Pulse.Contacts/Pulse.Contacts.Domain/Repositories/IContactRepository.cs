using Pulse.Contacts.Domain.Entities;

namespace Pulse.Contacts.Domain.Repositories;

public interface IContactRepository
{
    Task<Contact?> GetById(Guid id);
    Task<List<Contact>> GetAll();
    Task Add(Contact contact);
    Task Remove(Guid id);
}
