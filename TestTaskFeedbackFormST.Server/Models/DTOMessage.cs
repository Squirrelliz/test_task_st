using System.ComponentModel.DataAnnotations;

namespace TestTaskFeedbackFormST.Server.Models
{
    public class DTOMessage
    {
        [Required(ErrorMessage = "Укажите имя")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Укажите телефон")]
        [RegularExpression(@"[0-9]{5,13}",ErrorMessage = "Неверный ввод")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Укажите Email")]
        [EmailAddress(ErrorMessage = "Неверный ввод")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Выберите тему")]
        public string Topic { get; set; } = null!;
        [Required(ErrorMessage = "Введите сообщение")]
        public string MessageText { get; set; } = null!;
    }
}
