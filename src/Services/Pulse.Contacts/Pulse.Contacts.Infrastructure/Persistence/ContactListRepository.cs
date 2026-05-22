using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Infrastructure.Persistence;

public class ContactListRepository : IContactListRepository
{
    private readonly ContactsDbContext _context;

    public ContactListRepository(ContactsDbContext context)
    {
        _context = context;
    }

    public async Task<ContactList?> GetById(Guid id)
    {
        return await _context.ContactLists.FindAsync(id);
    }

    public async Task Add(ContactList contactList)
    {
        await _context.ContactLists.AddAsync(contactList);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Guid id)
    {
        var contactList = await GetById(id);
        if (contactList is null)
            return;
        _context.ContactLists.Remove(contactList);
        await _context.SaveChangesAsync();
    }
}
