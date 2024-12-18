namespace lab6.Services;

using lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class MockDataService : IDataService
{
    private List<AdaptationModule> _modules = new();
    private List<Employee> _employees = new()
    {
        new Employee { Id=1, FullName="Иванов И.И.", Department=new Department{Id=1,Name="Отдел IT"}, Position=new Position{Id=1,Name="Инженер"} },
        new Employee { Id=2, FullName="Петров П.П.", Department=new Department{Id=2,Name="Производство"}, Position=new Position{Id=2,Name="Мастер цеха"} }
    };
    private List<Department> _departments = new()
    {
        new Department{Id=1,Name="Отдел IT"},
        new Department{Id=2,Name="Производство"}
    };
    private List<Position> _positions = new()
    {
        new Position{Id=1,Name="Инженер"},
        new Position{Id=2,Name="Мастер цеха"}
    };

    public void AddModule(AdaptationModule module)
    {
        module.Id = _modules.Count + 1;
        _modules.Add(module);
    }

    public List<Department> GetAllDepartments() => _departments;
    public List<Employee> GetAllEmployees() => _employees;
    public List<Position> GetAllPositions() => _positions;
    public List<AdaptationModule> GetAllModules() => _modules;

    public void UpdateModule(AdaptationModule module)
    {
        var existing = _modules.FirstOrDefault(m => m.Id == module.Id);
        if (existing != null)
        {
            _modules.Remove(existing);
            _modules.Add(module);
        }
    }

    public void NotifyUsersByEmail(IEnumerable<string> emails, string subject, string body, string pdfPath = null)
    {
        // Заглушка
        Console.WriteLine("Отправка писем: " + subject);
    }

    public void SaveModulePdf(AdaptationModule module, string filePath)
    {
        // Заглушка сохранения PDF
    }

    public void UpdateModuleStatus(int moduleId, ModuleStatus status)
    {
        var m = _modules.FirstOrDefault(x => x.Id == moduleId);
        if (m != null) m.Status = status;
    }
}
