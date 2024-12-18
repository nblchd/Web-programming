using System;
using System.Collections.Generic;
using System.Linq;
using lab1;

public class Program
{
    public static void Main()
    {
        Library library = new Library();

        Book book = new Book("C# Programming", "John Doe", 2020, "123456789");
        Magazine magazine = new Magazine("Tech Today", "Jane Smith", 2021, 5);
        DVD dvd = new DVD("Inception", "Christopher Nolan", 2010, 148);

        library.AddItem(book);
        library.AddItem(magazine);
        library.AddItem(dvd);

        library.ProcessItem(book);
        library.ProcessItem(magazine);
        library.ProcessItem(dvd);

        if (library.Search("ml") != null)
        {
            Console.WriteLine($"search: {library.Search("ml").Title} \n");
        }
        else
        {
            Console.WriteLine("No results\n");
        }
        
        
        book.DisplayInfo();
        magazine.DisplayInfo();
        dvd.DisplayInfo();

        book.Borrow();
        book.Return();
        
        try
        {
            book.Return(); // Попытка вернуть уже возвращённый предмет
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}