namespace lab2;

public class EmailNotification : INotification
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Email sent to {recipient}: {message}");
    }
}