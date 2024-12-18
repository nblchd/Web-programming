namespace lab6.Models;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public Department Department { get; set; }
    public Position Position { get; set; }
    // ... другие поля
}