namespace lab5;

public class LogService
{
    public void Subscribe(Server server)
    {
        server.OnHighCPUUsage += CpuLog;
        server.OnHighMemoryUsage += MemLog;
        server.OnHighDowntime += DowntimeLog;
    }

    private void CpuLog(double cpu)
    {
        Console.WriteLine($"[LogService] {DateTime.Now}: Сработало событие высокой нагрузки CPU ({cpu:F2}%)");
    }

    private void MemLog(double mem)
    {
        Console.WriteLine($"[LogService] {DateTime.Now}: Сработало событие высокого использования памяти ({mem:F2}%)");
    }

    private void DowntimeLog(double dt)
    {
        Console.WriteLine($"[LogService] {DateTime.Now}: Сработало событие длительного простоя ({dt:F2} мин)");
    }
}