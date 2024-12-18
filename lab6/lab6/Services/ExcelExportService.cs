namespace lab6.Services;

using lab6.Models;

public class ExcelExportService
{
    public void ExportAdaptationProgram(string filePath, Employee employee, Department dept, Position pos, List<AdaptationModule> selectedModules)
    {
        // Генерация XLSX, заглушка
        Console.WriteLine($"Сохранен файл {filePath}");
    }
}
