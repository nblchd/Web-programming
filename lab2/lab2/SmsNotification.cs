namespace lab2;

public class SmsNotification : INotification
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"SMS sent to {recipient}: {message}");
    }
}