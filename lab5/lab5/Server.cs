namespace lab5;

public class Server
{
    public event Action<double> OnHighCPUUsage;
    public event Action<double> OnHighMemoryUsage;
    public event Action<double> OnHighDowntime;

    private readonly Random _rnd = new Random();

    public double CPUUsage { get; private set; }     // в процентах
    public double MemoryUsage { get; private set; }  // в процентах
    public double Downtime { get; private set; }     // в минутах

    public void UpdateServerStatus()
    {
        CPUUsage = _rnd.NextDouble() * 100;
        MemoryUsage = _rnd.NextDouble() * 100;
        Downtime = _rnd.NextDouble() * 20; 
        
        CheckThresholds();
    }

    private void CheckThresholds()
    {
        if (CPUUsage > 80) OnHighCPUUsage?.Invoke(CPUUsage);
        if (MemoryUsage > 75) OnHighMemoryUsage?.Invoke(MemoryUsage);
        if (Downtime > 10) OnHighDowntime?.Invoke(Downtime);
    }
}