using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Repositories
{
    public interface ImessageRepository
    {
        Task<Message?> CreateAsync(Message m);
        Task<IEnumerable<Message>> RetrieveAllAsync();
        Task<Message?> RetrieveAsync(int id);
        Task<Message?> UpdateAsync(Message m);
        Task<bool?> DeleteAsync(int id);
    }
}
