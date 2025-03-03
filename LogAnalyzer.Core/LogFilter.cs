namespace log_analyzer.LogAnalyzer.Core
{
    public class LogFilter
    {
        public IEnumerable<LogEntry> Filter(IEnumerable<LogEntry> logs, string? level = null,
            string? keyword = null, DateTime? from = null, DateTime? to = null)
        {
            return logs
            .Where(log => level == null || log.Level.Equals(level, StringComparison.OrdinalIgnoreCase))
            .Where(log => keyword == null || log.Message.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .Where(log => from == null || log.Timestamp >= from)
            .Where(log => to == null || log.Timestamp <= to)
            .OrderByDescending(log => log.Timestamp);
        }
    }
}
