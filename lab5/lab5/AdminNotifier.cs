namespace lab5;

public class AdminNotifier
{
    public void Subscribe(Server server)
    {
        server.OnHighCPUUsage += CpuAlert;
        server.OnHighMemoryUsage += MemoryAlert;
        server.OnHighDowntime += DowntimeAlert;
    }

    private void CpuAlert(double cpu)
    {
        Console.WriteLine($"[AdminNotifier] ВНИМАНИЕ: Высокая нагрузка CPU ({cpu:F2}%).");
    }

    private void MemoryAlert(double mem)
    {
        Console.WriteLine($"[AdminNotifier] ВНИМАНИЕ: Высокое использование памяти ({mem:F2}%).");
    }

    private void DowntimeAlert(double dt)
    {
        Console.WriteLine($"[AdminNotifier] ВНИМАНИЕ: Длительный простой ({dt:F2} мин).");
    }
}