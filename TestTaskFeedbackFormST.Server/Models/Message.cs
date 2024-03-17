using System;
using System.Collections.Generic;

namespace TestTaskFeedbackFormST.Server.Models;

public partial class Message
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public int TopicId { get; set; }

    public string MessageText { get; set; } = null!;

    public virtual Contact Contact { get; set; } = null!;

    public virtual DirectoryOfMessageTopic Topic { get; set; } = null!;
}
