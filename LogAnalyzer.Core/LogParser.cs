namespace log_analyzer.LogAnalyzer.Core
{
    public class LogParser
    {
        private const string parseSymbol = "|";
        public IEnumerable<LogEntry> Parse(string filePath)
        {
            return File.ReadLines(filePath)
                .Select(line => line.Split(parseSymbol).Select(part => part.Trim()).ToArray())
                .Where(parts => parts.Length == 3 && DateTime.TryParse(parts[0], out _))
                .Select(parts => new LogEntry(DateTime.Parse(parts[0]), parts[1], parts[2]));
        }
    }
}
