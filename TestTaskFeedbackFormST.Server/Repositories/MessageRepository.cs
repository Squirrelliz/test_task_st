using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestTaskFeedbackFormST.Server.DataContext;
using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Repositories
{
    public class MessageRepository
    {
        private DbOfUserRequestsContext db;


        public MessageRepository(DbOfUserRequestsContext injectedContext)
        {
            db = injectedContext;

        }
        public async Task<Message?> CreateAsync(Message m)
        {
            //to do: check email/phone/name
            EntityEntry<Message> added = await db.Messages.AddAsync(m);
            int affected = await db.SaveChangesAsync();

            return affected == 1 ? m : null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            Message? m = db.Messages.Find(id);
            if (m is null)
                return false;

            db.Messages.Remove(m);
            int affected = await db.SaveChangesAsync();

            return affected == 1 ? true : null;
        }

        public async Task<IEnumerable<Message>> RetrieveAllAsync()
        {
            return await db.Messages.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Message>> RetrieveAllAsync(int ContactId)
        {
            return await db.Messages.Include(m => m.ContactId == ContactId).AsNoTracking().ToListAsync();
        }

        public async Task<Message?> RetrieveAsync(int ContactId)
        {
            return await db.Messages.AsNoTracking().LastOrDefaultAsync(m => m.ContactId == ContactId);
        }

        public async Task<Message?> UpdateAsync(Message m)
        {
            db.Messages.Update(m);
            int affected = await db.SaveChangesAsync();
            return affected == 1 ? m : null;
        }
    }
}

