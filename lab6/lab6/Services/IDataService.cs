namespace lab6.Services;
using lab6.Models;

using System.Collections.Generic;

public interface IDataService
{
    List<AdaptationModule> GetAllModules();
    void AddModule(AdaptationModule module);
    void UpdateModule(AdaptationModule module);
    List<Employee> GetAllEmployees();
    List<Department> GetAllDepartments();
    List<Position> GetAllPositions();
    void NotifyUsersByEmail(IEnumerable<string> emails, string subject, string body, string pdfPath = null);
    void SaveModulePdf(AdaptationModule module, string filePath);
    void UpdateModuleStatus(int moduleId, ModuleStatus status);
}
