using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Numerics;
using TestTaskFeedbackFormST.Server.DataContext;
using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Repositories
{
    public class MessageRepository : ImessageRepository
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

        public async Task<Message?> CreateAsync(int ContactId, int TopicId, string MessageText)
        {
            //to do: check size of message
            Message m = new Message();
            m.TopicId = TopicId;
            m.ContactId = ContactId;
            m.MessageText = MessageText;

            return await CreateAsync(m);
        }

        public async Task<IEnumerable<Message>> RetrieveAllAsync(int ContactId)
        {
            return await db.Messages.Include(m => m.ContactId == ContactId).AsNoTracking().ToListAsync();
        }

        public Task<Message?> RetrieveAsyncByContact(int ContactId)
        {
            List<Message> query = db.Messages.FromSqlInterpolated($"SELECT TOP (1) [Id],[ContactID],[TopicID],[MessageText] FROM [db_of_user_requests].[dbo].[Messages] WHERE ContactID = {ContactId} ORDER BY Id DESC").ToList(); 
            Message? m = query.FirstOrDefault();
            return Task.FromResult(m);
        }

        public async Task<Message?> RetrieveAsync(int id)
        {
            return await db.Messages.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
        /*
                 public async Task<IEnumerable<Message>> RetrieveAllAsync()
        {
            return await db.Messages.AsNoTracking().ToListAsync();
        }
         public async Task<Message?> UpdateAsync(Message m)
         {
             db.Messages.Update(m);
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
         }*/

    }
}

