using Microsoft.EntityFrameworkCore;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;

namespace Pulse.Contacts.Infrastructure.Persistence;

public class ContactRepository : IContactRepository
{
    private readonly ContactsDbContext _context;

    public ContactRepository(ContactsDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Contact?> GetById(Guid id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public Task<List<Contact>> GetAll()
    {
        return _context.Contacts.ToListAsync();
    }

    public async Task Add(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Guid id)
    {
        var contact = await GetById(id);
        if (contact is null)
            return;
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
    }
}
