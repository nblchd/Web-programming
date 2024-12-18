namespace lab2;

public class NotificationService
{
    private readonly List<INotification> _notifications;

    public NotificationService(List<INotification> notifications)
    {
        _notifications = notifications;
    }

    public void NotifyAll(string message, string recipient)
    {
        foreach (var notification in _notifications)
        {
            notification.Send(message, recipient);
        }
    }
}