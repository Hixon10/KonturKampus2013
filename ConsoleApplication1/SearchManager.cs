using System;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// Управляющий поиском
    /// </summary>
    internal class SearchManager
    {
        private readonly ISearcher _searcher;
        private const int MaxNumberOfMatches = 20;

        public SearchManager(ISearcher searcher)
        {
            _searcher = searcher;
        }

        /// <summary>
        /// Создание результата для вывода на консоль
        /// </summary>
        /// <param name="lines">строки</param>
        /// <param name="queries">поисковое запросы</param>
        /// <returns>строка для вывода</returns>
        public string Search(string[] lines, string[] queries)
        {
            if (lines == null)
            {
                throw new NullReferenceException("lines");
            }

            if (queries == null)
            {
                throw new NullReferenceException("queries");
            }

            var result = new StringBuilder();

            foreach (var query in queries)
            {
                result.Append(SearchByQueryInAllLines(lines, query));
            }

            return result.ToString().TrimEnd();
        }

        /// <summary>
        /// Поиск по ключевому запросу по всем строкам
        /// </summary>
        /// <param name="lines">Строки</param>
        /// <param name="query">Запрос</param>
        /// <returns>Строки, где запрос нашёлся</returns>
        private string SearchByQueryInAllLines(string[] lines, string query)
        {
            var sb = new StringBuilder();
            int counter = 0;
            bool isNeedNewLine = false;
            
            for (int i = 0; i < lines.Length; i++)
            {
                if (!_searcher.IsContainsSearchQueryInLine(lines[i], query))
                {
                    continue;
                }

                isNeedNewLine = true;

                sb.Append(i.ToString());
                counter++;

                if (counter < MaxNumberOfMatches)
                {
                    sb.Append(", ");
                }
                else
                {
                    break;
                }
            }

            if (counter < MaxNumberOfMatches)
            {
                if (sb.Length < 2)
                {
                    sb.Length = 0;
                }
                else
                {
                    sb.Length -= 2;
                }
            }

            if (isNeedNewLine)
            {
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}