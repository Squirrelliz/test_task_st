using TestTaskFeedbackFormST.Server.Models;
using TestTaskFeedbackFormST.Server.Repositories;
using TestTaskFeedbackFormST.Server.Services;
namespace TestTaskFeedbackFormST.Server.Services
{
    public class MessageService : ImessageService
    {
        private readonly IdirectoryOfMessageTopicRepository repoTopics;
        private readonly IсontactRepository repoContact;
        private readonly ImessageRepository repoMessage;
        public MessageService(IdirectoryOfMessageTopicRepository repoTopics,
            IсontactRepository repoContact, ImessageRepository repoMessage)
        {
            this.repoTopics = repoTopics;
            this.repoContact = repoContact;
            this.repoMessage = repoMessage;
        }

        public async Task<Message?> CreateAsync(DTOMessage m)
        {
            Contact? c = await repoContact.RetrieveAsync(m.email, m.phone);

            if (c is null)
            {
                c = await repoContact.CreateAsync(m.name, m.email, m.phone);
                if (c is null)
                {
                    return null;
                }
            }

            DirectoryOfMessageTopic? t = await repoTopics.RetrieveAsync(m.topic);
            if (t is null)
            {
                return null;
            }

            return await repoMessage.CreateAsync(c.Id, t.Id, m.messageText);
        }

        public async Task<DTOMessage?> RetrieveAsync(int id)
        {
            Message? m = await repoMessage.RetrieveAsync(id);
            if (m is null)
                return null;
            Contact? c = await repoContact.RetrieveAsync(m.ContactId);
            DirectoryOfMessageTopic? t = await repoTopics.RetrieveAsync(m.TopicId);
            if (t is null || c is null  || m is null)
            {
                return null;
            }

            DTOMessage message = new DTOMessage();
            message.name = c.Name; 
            message.email=c.Email; 
            message.phone = c.Phone;
            message.topic = t.Topic;
            message.messageText = m.MessageText;

            return message;
        }
    }
}
