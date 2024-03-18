using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestTaskFeedbackFormST.Server.DataContext;
using TestTaskFeedbackFormST.Server.Models;


namespace TestTaskFeedbackFormST.Server.Repositories
{
    public class DirectoryOfMessageTopicRepository : IdirectoryOfMessageTopicRepository
    {
        private DbOfUserRequestsContext db;


        public DirectoryOfMessageTopicRepository(DbOfUserRequestsContext injectedContext)
        {
            db = injectedContext;

        }
        public async Task<DirectoryOfMessageTopic?> CreateAsync(DirectoryOfMessageTopic d)
        {
            //to do: check 
            EntityEntry<DirectoryOfMessageTopic> added = await db.DirectoryOfMessageTopics.AddAsync(d);
            int affected = await db.SaveChangesAsync();

            return affected == 1 ? d : null;
        }

        public async Task<IEnumerable<DirectoryOfMessageTopic>> RetrieveAllAsync()
        {
            return await db.DirectoryOfMessageTopics.AsNoTracking().ToListAsync();
        }

        public async Task<DirectoryOfMessageTopic?> RetrieveAsync(string topic)
        {
            return await db.DirectoryOfMessageTopics.AsNoTracking().FirstOrDefaultAsync(d => d.Topic == topic);
        }

        public async Task<DirectoryOfMessageTopic?> RetrieveAsync(int id)
        {
            return await db.DirectoryOfMessageTopics.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
        }

        /*  public async Task<DirectoryOfMessageTopic?> UpdateAsync(DirectoryOfMessageTopic d)
          {
              db.DirectoryOfMessageTopics.Update(d);
              int affected = await db.SaveChangesAsync();
              return affected == 1 ? d : null;
          }

          public async Task<bool?> DeleteAsync(int id)
          {
              DirectoryOfMessageTopic? d = db.DirectoryOfMessageTopics.Find(id);
              if (d is null)
                  return false;

              db.DirectoryOfMessageTopics.Remove(d);
              int affected = await db.SaveChangesAsync();

              return affected == 1 ? true : null;
          }
        */
    }
}
