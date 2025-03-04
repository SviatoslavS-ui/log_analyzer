using log_analyzer.LogAnalyzer.Core;
using log_analyzer.LogAnalyzer.Files;

namespace log_analyzer
{
    internal class Program
    {
        internal static ILogFileProcessor? fileProcessor = null;
        internal static LogParser? logParser;
        internal static LogFilter? logFilter;

        static void Main(string[] args)
        {
            logParser = new LogParser();
            logFilter = new LogFilter();

            var menuOptions = new Dictionary<string, Action>
            {
                { "1", LoadLogFile },
                { "2", ApplyFilter },
                { "3", ViewLogs },
                { "4", SaveLogs },
                { "5", () => Environment.Exit(0) }
            };

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Log Analyzer");
                Console.WriteLine("1. Load Log File");
                Console.WriteLine("2. Apply Filter");
                Console.WriteLine("3. View Filtered Logs");
                Console.WriteLine("4. Save Filtered Logs");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                // Используем LINQ для обработки ввода
                menuOptions
                    .Where(option => option.Key == choice)
                    .ToList()
                    .ForEach(option => option.Value.Invoke());
            }
        }

        static void LoadLogFile()
        {
            Console.Write("Enter the path to the log file: ");
            var path = Console.ReadLine();

            if (File.Exists(path))
            {
                fileProcessor ??= new LogFileProcessor();
                var logs = fileProcessor.ReadLogs(path);

                if (logs.Any())
                {
                    // Load and parse the file
                    Console.WriteLine("File loaded successfully.");
                    logs.Select(log => log.ToString()).ToList().ForEach(Console.WriteLine);
                }
                else
                {
                    Console.WriteLine("No logs to print ...");
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
            Console.ReadKey();
        }

        static void ApplyFilter()
        {
            Console.WriteLine("Applying filters...");
            // Implement filter logic
            Console.ReadKey();
        }

        static void ViewLogs()
        {
            Console.WriteLine("Displaying logs...");
            // Show filtered logs
            Console.ReadKey();
        }

        static void SaveLogs()
        {
            Console.Write("Enter the file path to save filtered logs: ");
            var path = Console.ReadLine();
            // Save filtered logs to file
            Console.WriteLine("Logs saved.");
            Console.ReadKey();
        }
    }
}


