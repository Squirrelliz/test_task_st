using TestTaskFeedbackFormST.Server.Models;
using TestTaskFeedbackFormST.Server.Repositories;

namespace TestTaskFeedbackFormST.Server.Services
{
    public class DirectoryOfMessageTopicsService : IdirectoryOfMessageTopicsService
    {
        private readonly IdirectoryOfMessageTopicRepository repoTopics;
        public DirectoryOfMessageTopicsService(IdirectoryOfMessageTopicRepository repoTopics)
        {
            this.repoTopics = repoTopics;
            
        }
        public async Task<IEnumerable<DirectoryOfMessageTopic?>> RetrieveAllAsync()
        {
            return await repoTopics.RetrieveAllAsync();
        }
    }
}
