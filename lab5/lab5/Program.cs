using System;
using System.Threading;
using lab5;


public static class Program
{
    public static void Main()
    {
        var server = new Server();
        var adminNotifier = new AdminNotifier();
        var logService = new LogService();

        adminNotifier.Subscribe(server);
        logService.Subscribe(server);

        Console.WriteLine("Начинаем мониторинг сервера. Нажмите Ctrl+C для выхода.");

        while (true)
        {
            server.UpdateServerStatus();
            // Выводим текущее состояние для наглядности
            Console.WriteLine($"Состояние: CPU={server.CPUUsage:F2}% Mem={server.MemoryUsage:F2}% Downtime={server.Downtime:F2}мин");
            Thread.Sleep(2000); // имитация периодического обновления статуса
        }
    }
}
