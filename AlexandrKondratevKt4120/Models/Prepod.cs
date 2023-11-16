using System.Text.RegularExpressions;

namespace AlexandrKondratevKt4120.Models
{
    public class Prepod
    {
        public int PrepodId { get; set; }
        public string? PrepodName { get; set; }
        public ICollection<Discipline>? Disciplines { get; set; }

        public bool IsValidPrepodName() // Проверка формата ввода PrepodName (Фамилия Имя Отчество)
        {
            return Regex.Match(PrepodName, @"^[А-ЯЁ][а-яё]*\s[А-ЯЁ][а-яё]*\s[А-ЯЁ][а-яё]*$").Success;
        }
    }
}
