namespace lab2;

public class PushNotification : INotification
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Push sent to {recipient}: {message}");
    }
}