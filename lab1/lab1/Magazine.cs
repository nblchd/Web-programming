namespace lab1;

public class Magazine : LibraryItem
{
    private int IssueNumber { get; set; }

    public Magazine(string title, string author, int year, int issueNumber)
        : base(title, author, year)
    {
        IssueNumber = issueNumber;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Issue Number: {IssueNumber}\n");
    }
}