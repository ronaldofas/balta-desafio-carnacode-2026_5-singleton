using System;
using DesignPatternChallenge.Services;

namespace DesignPatternChallenge;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Configurações (Singleton) ===\n");

        // Singleton: apenas uma instância é criada
        Console.WriteLine("Inicializando serviços...\n");

        var dbService = new DatabaseService();
        var apiService = new ApiService();
        var cacheService = new CacheService();
        var logService = new LoggingService();

        Console.WriteLine("\nUsando os serviços...\n");

        dbService.Connect();
        apiService.MakeRequest();
        cacheService.Connect();
        logService.Log("Sistema iniciado");

        // Demonstrando consistência: a atualização é visível em todo lugar
        Console.WriteLine("\n--- Demonstrando consistência ---\n");

        var config = ConfigurationManager.Instance;
        config.UpdateSetting("LogLevel", "Debug");

        // Todos os serviços enxergam a mesma configuração
        logService.Log("Após atualização do LogLevel");

        Console.WriteLine($"\nLogLevel atual: {config.GetSetting("LogLevel")}");
        Console.WriteLine("✅ Consistência garantida: todos compartilham a mesma instância!");

        Console.WriteLine("\n--- Impacto de Performance ---");
        Console.WriteLine("As configurações foram carregadas apenas uma vez");
        Console.WriteLine("Todos os serviços compartilham a mesma instância");
        Console.WriteLine("Memória e tempo de inicialização otimizados!");
    }
}
