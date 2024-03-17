using System.Collections.Generic;
using TestTaskFeedbackFormST.Server.DataContext;
using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Repositories
{
    public interface IсontactRepository
    {
        Task<Contact?> CreateAsync(Contact c);
        Task<IEnumerable<Contact>> RetrieveAllAsync();
        Task<Contact?> RetrieveAsync(int id);
        Task<Contact?> UpdateAsync( Contact c);
        Task<bool?> DeleteAsync(int id);
    }
}
