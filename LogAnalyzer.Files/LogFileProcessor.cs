using log_analyzer.LogAnalyzer.Core;

namespace log_analyzer.LogAnalyzer.Files
{
    public class LogFileProcessor : ILogFileProcessor
    {
        public IEnumerable<LogEntry> ReadLogs(string fileName)
        {
            var parser = new LogParser();
            return parser.Parse(File.ReadAllLines(fileName)).Where(line => line != null);
        }

        public void WriteLogs(string fileName, IEnumerable<LogEntry> logs)
        {
            if(logs == null || !logs.Any()) return;

            var logLines = logs.Select(log => $"{log.Timestamp:yyyy-MM-dd HH:mm:ss} | {log.Level} | {log.Message}");
            File.WriteAllLines(fileName, logLines);
        }
    }
}
