using System;
using System.Linq;

namespace ConsoleApplication1
{
    /// <summary>
    /// Поиск поискового запроса в строке
    /// </summary>
    internal class Searcher : ISearcher
    {
        /// <summary>
        /// Проверка на то, что поисковой запрос содержится в строке
        /// </summary>
        /// <param name="line">Строка</param>
        /// <param name="query">Поисковой запрос</param>
        /// <returns>bool</returns>
        public bool IsContainsSearchQueryInLine(string line, string query)
        {
            if (line == null)
            {
                throw new NullReferenceException("line");
            }

            if (query == null)
            {
                throw new NullReferenceException("query");
            }

            var keywords = query.Split(new char[] { ' ' });

            foreach (var keyword in keywords)
            {
                var words = line.Split(new char[] { ' ' });

                if (!words.Contains(keyword, StringComparer.OrdinalIgnoreCase))
                {
                    return false;
                }

                line = RemoveKeywordFromLine(line, keyword);
            }

            return true;
        }

        /// <summary>
        /// Удаление использовавшегося ключевого слова из строки
        /// </summary>
        /// <param name="line">строка</param>
        /// <param name="keyword">ключевое слово</param>
        /// <returns>Строка без ключевого слова</returns>
        private string RemoveKeywordFromLine(string line, string keyword)
        {
            int index = line.IndexOf(keyword, StringComparison.InvariantCulture);
            string cleanString = (index < 0) ? line : line.Remove(index, keyword.Length);

            return cleanString;
        }
    }
}