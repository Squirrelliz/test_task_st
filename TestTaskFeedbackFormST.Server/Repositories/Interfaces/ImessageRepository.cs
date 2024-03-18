using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Repositories
{
    public interface ImessageRepository
    {
        Task<Message?> CreateAsync(Message m);
        Task<Message?> CreateAsync(int ContactId, int TopicId, string MessageText);
        Task<IEnumerable<Message>> RetrieveAllAsync(int ContactId);
        Task<Message?> RetrieveAsyncByContact(int ContactId);
        Task<Message?> RetrieveAsync(int id);



        /* Task<IEnumerable<Message>> RetrieveAllAsync();
         Task<Message?> UpdateAsync(Message m);
         Task<bool?> DeleteAsync(int id);*/
    }
}
