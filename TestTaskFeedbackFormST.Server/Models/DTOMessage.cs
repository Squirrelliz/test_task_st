using System.ComponentModel.DataAnnotations;

namespace TestTaskFeedbackFormST.Server.Models
{
    public class DTOMessage
    {
        [Required(ErrorMessage = "Укажите имя")]
        public string name { get; set; } = null!;
        [Required(ErrorMessage = "Укажите телефон")]
        [RegularExpression(@"[0-9]{5,13}",ErrorMessage = "Неверный ввод")]
        public string phone { get; set; } = null!;
        [Required(ErrorMessage = "Укажите Email")]
        [EmailAddress(ErrorMessage = "Неверный ввод")]
        public string email { get; set; } = null!;
        [Required(ErrorMessage = "Выберите тему")]
        public string topic { get; set; } = null!;
        [Required(ErrorMessage = "Введите сообщение")]
        public string messageText { get; set; } = null!;
    }
}
