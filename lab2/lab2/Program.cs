using lab2;


class Program
{
    static void Main(string[] args)
    {
        // Создаем экземпляры уведомлений
        var emailNotification = new EmailNotification();
        var smsNotification = new SmsNotification();
        var pushNotification = new PushNotification();

        // Добавляем их в список
        var notifications = new List<INotification> { emailNotification, smsNotification, pushNotification };

        // Создаем службу уведомлений и отправляем сообщение
        var notificationService = new NotificationService(notifications);
        notificationService.NotifyAll("Hello, this is a test notification!", "user@example.com");
    }
}