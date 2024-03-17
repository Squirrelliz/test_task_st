using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTaskFeedbackFormST.Server.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
