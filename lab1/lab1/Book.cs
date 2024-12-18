namespace lab1;

public class Book : LibraryItem
{
    private string ISBN { get; set; }

    public Book(string title, string author, int year, string isbn)
        : base(title, author, year)
    {
        ISBN = isbn;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"ISBN: {ISBN}\n");
    }
}