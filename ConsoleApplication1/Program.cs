using System;
using System.IO;

namespace ConsoleApplication1
{
    public class Program
    {
        static private string textPath;
        static private string queryPath;

        static void Main(string[] args)
        {
            Initialize(args);

            var text = File.ReadAllText(textPath);

            var preprocessor = new Preprocessor();
            var lines = preprocessor.SplitTextIntoLines(text);

            var queries = File.ReadAllLines(queryPath);

            var searcher = new Searcher();
            var searchManager = new SearchManager(searcher);

            var result = searchManager.Search(lines, queries);

            Console.WriteLine(result);

            Console.ReadKey();
        }

        /// <summary>
        /// Инициализация 
        /// </summary>
        /// <param name="args">переменные командной строки</param>
        private static void Initialize(string[] args)
        {
            if (args == null)
            {
                throw new NullReferenceException("args");
            }

            if (args.Length < 2)
            {
                throw new ArgumentException("Не переданы файлы");
            }

            if (!String.IsNullOrWhiteSpace(args[0]))
            {
                textPath = args[0];
            }
            else
            {
                throw new ArgumentException("Не переданы файлы");
            }

            if (!String.IsNullOrWhiteSpace(args[1]))
            {
                queryPath = args[1];
            }
            else
            {
                throw new ArgumentException("Не переданы файлы");
            }
        }
    }
}
