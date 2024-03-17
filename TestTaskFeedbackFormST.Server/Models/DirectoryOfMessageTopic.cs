using System;
using System.Collections.Generic;

namespace TestTaskFeedbackFormST.Server.Models;

public partial class DirectoryOfMessageTopic
{
    public int Id { get; set; }

    public string Topic { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
