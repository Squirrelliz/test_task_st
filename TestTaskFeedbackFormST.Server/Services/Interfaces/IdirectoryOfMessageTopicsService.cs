using TestTaskFeedbackFormST.Server.Models;
namespace TestTaskFeedbackFormST.Server.Services
{
    public interface IdirectoryOfMessageTopicsService
    {
        IEnumerable<string> RetrieveAllAsync();
    }
}
