namespace lab6.Models;

public enum EventType { Теория, Практика }

public class ModuleEvent
{
    public int Id { get; set; }
    public string Title { get; set; }
    public EventType Type { get; set; }
    public string Content { get; set; }
    public string AddedBy { get; set; }
    public DateTime AddedAt { get; set; }
}