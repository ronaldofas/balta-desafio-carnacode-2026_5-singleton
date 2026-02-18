using System;

namespace DesignPatternChallenge.Services;

public class LoggingService
{
    private readonly ConfigurationManager _config;

    public LoggingService()
    {
        _config = ConfigurationManager.Instance;
    }

    public void Log(string message)
    {
        var logLevel = _config.GetSetting("LogLevel");
        Console.WriteLine($"[LoggingService] [{logLevel}] {message}");
    }
}
