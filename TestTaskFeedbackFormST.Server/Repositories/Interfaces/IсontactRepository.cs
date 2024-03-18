using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Repositories
{
    public interface IсontactRepository
    {
        Task<Contact?> CreateAsync(Contact c);
        Task<Contact?> RetrieveAsync(string email, string phone);
        Task<Contact?> RetrieveAsync(int id);
        Task<Contact?> CreateAsync(string name, string email, string phone);

        /*
        Task<IEnumerable<Contact>> RetrieveAllAsync();
        
        Task<Contact?> UpdateAsync(Contact c);
        Task<bool?> DeleteAsync(int id);
        */
    }
}
