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
            Contact? c = await repoContact.RetrieveAsync(m.Email, m.Phone);

            if (c is null)
            {
                c = await repoContact.CreateAsync(m.Name, m.Email, m.Phone);
                if (c is null)
                {
                    return null;
                }
            }

            DirectoryOfMessageTopic? t = await repoTopics.RetrieveAsync(m.Topic);
            if (t is null)
            {
                return null;
            }

            return await repoMessage.CreateAsync(c.Id, t.Id, m.MessageText);
        }

        public  Task<Message?> RetrieveAsyncByContact(int ContactId)
        {
            return  repoMessage.RetrieveAsyncByContact(ContactId);
        }

        public async Task<DTOMessage?> RetrieveAsync(int id)
        {
            Message? m = await repoMessage.RetrieveAsync(id);
            Contact? c = await repoContact.RetrieveAsync(id);
            DirectoryOfMessageTopic? t = await repoTopics.RetrieveAsync(id);
            if (t is null || c is null  || m is null)
            {
                return null;
            }

            DTOMessage message =new DTOMessage();
            message.Name = c.Name; 
            message.Email=c.Email; 
            message.Phone = c.Phone;
            message.Topic = t.Topic;
            message.MessageText = m.MessageText;

            return message;
        }
    }
}
