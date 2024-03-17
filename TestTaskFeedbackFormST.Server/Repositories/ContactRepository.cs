using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using TestTaskFeedbackFormST.Server.DataContext;
using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Repositories
{
    public class ContactRepository : IсontactRepository
    {

        private DbOfUserRequestsContext db;
        
        public ContactRepository(DbOfUserRequestsContext injectedContext)
        {
            db = injectedContext;
        }
        public async Task<Contact?> CreateAsync(Contact c)
        {
            //to do: check email/phone/name
            EntityEntry<Contact> added = await db.Contacts.AddAsync(c);
            int affected = await db.SaveChangesAsync();
            
            return affected == 1? c: null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Contact? c = db.Contacts.Find(id);
            if (c is null) 
                return false;

            db.Contacts.Remove(c);
            int affected = await db.SaveChangesAsync();

            return affected == 1 ? true : null;
        }

        public async Task<IEnumerable<Contact>> RetrieveAllAsync()
        {
            return await db.Contacts.AsNoTracking().ToListAsync();
        }

        public async Task<Contact?> RetrieveAsync(int id)
        {
            return await db.Contacts.AsNoTracking().FirstOrDefaultAsync(c=>c.Id==id);
        }

        public async Task<Contact?> UpdateAsync( Contact c)
        {
            db.Contacts.Update(c);
            int affected = await db.SaveChangesAsync();
            return affected == 1 ? c : null;
        }
    }
}
