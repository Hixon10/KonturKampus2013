using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// Предварительная обработка текста
    /// </summary>
    internal class Preprocessor
    {
        /// <summary>
        /// Деление текста на строки
        /// </summary>
        /// <param name="text">Текст</param>
        /// <returns>Строки</returns>
        public string[] SplitTextIntoLines(string text)
        {
            if (text == null)
            {
                throw new NullReferenceException("text");
            }

            string textWithoutSpecialCharacters = RemoveSpecialCharacters(text);
            string[] lines = textWithoutSpecialCharacters.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return lines;
        }

        /// <summary>
        /// Удаление символов из текста, которых не может быть в ключевых запросах
        /// </summary>
        /// <param name="text">Текст</param>
        /// <returns>Очищенный от символов текст</returns>
        private string RemoveSpecialCharacters(string text)
        {
            var sb = new StringBuilder();
            foreach (var c in text.Where(IsNotSpecialCharacters))
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Проверка на то, что символ не является специальным
        /// </summary>
        /// <param name="c">символ</param>
        /// <returns>bool</returns>
        private bool IsNotSpecialCharacters(char c)
        {
            return (c <= 'Z' && c >= 'A') ||
                   (c <= 'z' && c >= 'a') ||
                   (c >= 'А' && c <= 'Я') ||
                   (c >= 'а' && c <= 'я') ||
                   (c >= '0' && c <= '9') ||
                   c == 'Ё' ||
                   c == 'ё' ||
                   c == '_' ||
                   c == ' ' ||
                   c == '\r' ||
                   c == '\n';
        }
    }
}