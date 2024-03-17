﻿using System.Collections.Generic;
using TestTaskFeedbackFormST.Server.DataContext;
using TestTaskFeedbackFormST.Server.Models;

namespace TestTaskFeedbackFormST.Server.Repositories
{
    public interface IdirectoryOfMessageTopicRepository
    {
        Task<DirectoryOfMessageTopic?> CreateAsync(DirectoryOfMessageTopic d);
        Task<IEnumerable<DirectoryOfMessageTopic>> RetrieveAllAsync();
        Task<DirectoryOfMessageTopic?> RetrieveAsync(int id);
        Task<DirectoryOfMessageTopic?> UpdateAsync(DirectoryOfMessageTopic d);
        Task<bool?> DeleteAsync(int id);
    }
}