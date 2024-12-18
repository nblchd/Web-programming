namespace lab1;

public class DVD : LibraryItem
{
    private int Duration { get; set; }

    public DVD(string title, string author, int year, int duration)
        : base(title, author, year)
    {
        Duration = duration;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Duration: {Duration} minutes\n");
    }
}