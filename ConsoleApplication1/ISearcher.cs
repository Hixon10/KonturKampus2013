namespace ConsoleApplication1
{
    internal interface ISearcher
    {
        /// <summary>
        /// Проверка на то, что поисковой запрос содержится в строке
        /// </summary>
        /// <param name="line">Строка</param>
        /// <param name="query">Поисковой запрос</param>
        /// <returns>bool</returns>
        bool IsContainsSearchQueryInLine(string line, string query);
    }
}