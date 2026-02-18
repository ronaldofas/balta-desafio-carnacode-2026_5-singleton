using System;

namespace DesignPatternChallenge.Services;

public class CacheService
{
    private readonly ConfigurationManager _config;

    public CacheService()
    {
        _config = ConfigurationManager.Instance;
    }

    public void Connect()
    {
        var cacheServer = _config.GetSetting("CacheServer");
        Console.WriteLine($"[CacheService] Conectando ao cache: {cacheServer}");
    }
}
