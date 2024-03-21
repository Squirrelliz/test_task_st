using System.Collections.Generic;
using TestTaskFeedbackFormST.Server.DataContext;
using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Repositories
{
    public interface IdirectoryOfMessageTopicRepository
    {
        Task<DirectoryOfMessageTopic?> CreateAsync(DirectoryOfMessageTopic d);
        IEnumerable<string> RetrieveAllAsync();
        Task<DirectoryOfMessageTopic?> RetrieveAsync(string topic);
        Task<DirectoryOfMessageTopic?> RetrieveAsync(int id);
        /*
        Task<DirectoryOfMessageTopic?> UpdateAsync(DirectoryOfMessageTopic d);
        Task<bool?> DeleteAsync(int id);
        */
    }
}
