using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Services
{
    public interface ImessageService
    {
        Task<Message?> CreateAsync(DTOMessage m);
        Task<DTOMessage?> RetrieveAsync(int id);
    }

}
