using System;
using System.Collections.Generic;

namespace DesignPatternChallenge;

public class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> _instance =
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());

    public static ConfigurationManager Instance => _instance.Value;

    private readonly Dictionary<string, string> _settings;
    private bool _isLoaded;

    private ConfigurationManager()
    {
        _settings = new Dictionary<string, string>();
        _isLoaded = false;
        Console.WriteLine("✅ Instância única de ConfigurationManager criada!");
    }

    public void LoadConfigurations()
    {
        if (_isLoaded)
        {
            Console.WriteLine("Configurações já carregadas.");
            return;
        }

        Console.WriteLine("🔄 Carregando configurações...");

        // Simulando operação custosa de carregamento
        System.Threading.Thread.Sleep(200);

        // Carregando configurações de diferentes fontes
        _settings["DatabaseConnection"] = "Server=localhost;Database=MyApp;";
        _settings["ApiKey"] = "abc123xyz789";
        _settings["CacheServer"] = "redis://localhost:6379";
        _settings["MaxRetries"] = "3";
        _settings["TimeoutSeconds"] = "30";
        _settings["EnableLogging"] = "true";
        _settings["LogLevel"] = "Information";

        _isLoaded = true;
        Console.WriteLine("✅ Configurações carregadas com sucesso!\n");
    }

    public string? GetSetting(string key)
    {
        if (!_isLoaded)
            LoadConfigurations();

        if (_settings.TryGetValue(key, out var value))
            return value;

        return null;
    }

    public void UpdateSetting(string key, string value)
    {
        _settings[key] = value;
        Console.WriteLine($"Configuração atualizada: {key} = {value}");
    }
}
