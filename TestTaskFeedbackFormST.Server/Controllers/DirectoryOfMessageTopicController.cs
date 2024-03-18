using Microsoft.AspNetCore.Mvc;
using TestTaskFeedbackFormST.Server.Models;
using TestTaskFeedbackFormST.Server.Services;

namespace TestTaskFeedbackFormST.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DirectoryOfMessageTopicController : ControllerBase
    {
        private readonly IdirectoryOfMessageTopicsService service;

        public DirectoryOfMessageTopicController(IdirectoryOfMessageTopicsService service)
        {
            this. service = service;;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DirectoryOfMessageTopic>))]
        public async Task<IEnumerable<DirectoryOfMessageTopic?>> GetDirectoryOfMessageTopics()
        {
            return await service.RetrieveAllAsync();
        }
    }
}