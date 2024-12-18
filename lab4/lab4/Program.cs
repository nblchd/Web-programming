using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Write("Введите задержку (секунды): ");
        if (!int.TryParse(Console.ReadLine(), out int delay) || delay < 1)
        {
            Console.WriteLine("Некорректный ввод");
            return;
        }
        
        for (int i = 1; i <= delay; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }

        Console.WriteLine("Задержка истекла.");
    }
}