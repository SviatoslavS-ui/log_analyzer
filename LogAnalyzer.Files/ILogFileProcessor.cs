using log_analyzer.LogAnalyzer.Core;

namespace log_analyzer.LogAnalyzer.Files
{
    public interface ILogFileProcessor
    {
        IEnumerable<LogEntry> ReadLogs(string fileName);
        void WriteLogs(string fileName, IEnumerable<LogEntry> logs);
    }
}