namespace lab6.Models;

public class NotificationMessage
{
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
}