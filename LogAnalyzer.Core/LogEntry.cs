namespace log_analyzer.LogAnalyzer.Core
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }  /// INFO, ERROR, WARNING
        public string Message { get; set; }

        public LogEntry(DateTime dateTime, string level, string message)
        {
            Timestamp = dateTime;
            Level = level;
            Message = message;
        }

        public override string ToString()
        {
            string levelText = string.IsNullOrEmpty(Level) ? "N/A" : Level;
            string messageText = string.IsNullOrEmpty(Message) ? "No message" : Message;

            return $"{Timestamp:yyyy-MM-dd HH:mm:ss} [{levelText}] : {messageText}";
        }
    }

    
}
