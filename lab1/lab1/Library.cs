namespace lab1;

public class Library : ISearchable
{
    private List<LibraryItem> _items;

    public Library()
    {
        _items = new List<LibraryItem>();
    }

    public void AddItem(LibraryItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(LibraryItem item)
    {
        _items.Remove(item);
    }

    public LibraryItem Search(string query)
    {
        
        return _items.FirstOrDefault(i => i.Title.Contains(query) || i.Author.Contains(query));
        
    }

    public void ProcessItem(LibraryItem item)
    {
        if (item is Book)
        {
            Console.WriteLine("Processing a Book...\n");
        }
        else if (item is Magazine)
        {
            Console.WriteLine("Processing a Magazine...\n");
        }
        else if (item is DVD)
        {
            Console.WriteLine("Processing a DVD...\n");
        }
    }
}
