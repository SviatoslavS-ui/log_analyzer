namespace log_analyzer.LogAnalyzer.Core
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }  /// INFO, ERROR, WARNING
        public string Message { get; set; }

        public LogEntry(DateTime dateTime, string level, string Message)
        {
            this.Timestamp = dateTime;
            this.Level = level;
            this.Message = Message;
        }
    }

    
}
