using TestTaskFeedbackFormST.Server.Models;
namespace TestTaskFeedbackFormST.Server.Services
{
    public interface IdirectoryOfMessageTopicsService
    {
        Task<IEnumerable<DirectoryOfMessageTopic?>> RetrieveAllAsync();
    }
}
