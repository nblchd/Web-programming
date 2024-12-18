namespace lab1;

public class LibraryItem
{
    private string title;
    private string author;
    private int year;
    private bool isAvailable;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    private int Year
    {
        get { return year; }
        set { year = value; }
    }

    private bool IsAvailable
    {
        get { return isAvailable; }
        set { isAvailable = value; }
    }

    protected LibraryItem(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
        IsAvailable = true; // По умолчанию предмет доступен
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Year: {Year}, Available: {IsAvailable}");
    }

    public void Borrow()
    {
        if (!IsAvailable)
        {
            throw new InvalidOperationException("Item is already borrowed.");
        }
        IsAvailable = false;
        Console.WriteLine($"{Title} has been borrowed.\n");
    }

    public void Return()
    {
        if (IsAvailable)
        {
            throw new InvalidOperationException("Item is already returned.");
        }
        IsAvailable = true;
        Console.WriteLine($"{Title} has been returned.\n");
    }
}
