
namespace ValidityChecker.Util;

public interface ILogger
{
    void LogDebug(string message);
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message);
}

public class ConsoleLogger : ILogger
{
    public ConsoleLogger() {}

    public void LogDebug(string message)
    {
        LogToConsole("DEBUG", message);
    }

    public void LogInfo(string message)
    {
        LogToConsole("INFO", message);
    }

    public void LogWarning(string message)
    {
        LogToConsole("WARNING", message);
    }

    public void LogError(string message)
    {
        LogToConsole("ERROR", message);
    }

    private void LogToConsole(string logLevel, string message)
    {
        Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {message}");
    }
}

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void LogDebug(string message)
    {
        LogToFile("DEBUG", message);
    }

    public void LogInfo(string message)
    {
        LogToFile("INFO", message);
    }

    public void LogWarning(string message)
    {
        LogToFile("WARNING", message);
    }

    public void LogError(string message)
    {
        LogToFile("ERROR", message);
    }

    private void LogToFile(string logLevel, string message)
    {
        var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {message}";
        File.AppendAllText(_filePath, logMessage + Environment.NewLine);
    }
}