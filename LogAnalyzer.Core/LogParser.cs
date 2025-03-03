namespace log_analyzer.LogAnalyzer.Core
{
    public class LogParser
    {
        public IEnumerable<LogEntry> Parse(IEnumerable<string> logLines, string parseSymbol = "|")
        {
            return logLines
                .Select(line => line.Split(parseSymbol).Select(part => part.Trim()).ToArray())
                .Where(parts => parts.Length == 3 && DateTime.TryParse(parts[0], out _))
                .Select(parts => new LogEntry(DateTime.Parse(parts[0]), parts[1], parts[2]));
        }
    }
}
