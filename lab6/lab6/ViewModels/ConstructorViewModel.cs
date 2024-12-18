namespace lab6.ViewModels;

using lab6.Models;
using lab6.Services;
using System.Collections.ObjectModel;
using System.Linq;

public class ConstructorViewModel : ViewModelBase
{
    private readonly IDataService _dataService;
    public ObservableCollection<Employee> Employees { get; set; } = new();
    public ObservableCollection<Department> Departments { get; set; } = new();
    public ObservableCollection<Position> Positions { get; set; } = new();
    public ObservableCollection<AdaptationModule> AvailableModules { get; set; } = new();

    private Employee _selectedEmployee;
    public Employee SelectedEmployee { get=>_selectedEmployee;set{_selectedEmployee=value; OnPropertyChanged(); LoadModules();}}
    private Department _selectedDepartment;
    public Department SelectedDepartment { get=>_selectedDepartment;set{_selectedDepartment=value;OnPropertyChanged();LoadModules();}}
    private Position _selectedPosition;
    public Position SelectedPosition { get=>_selectedPosition;set{_selectedPosition=value;OnPropertyChanged();LoadModules();}}

    public RelayCommand GenerateProgramCommand { get; set; }
    public ObservableCollection<AdaptationModule> SelectedModules {get;set;} = new();

    public ConstructorViewModel(IDataService dataService)
    {
        _dataService=dataService;
        LoadData();
        GenerateProgramCommand=new RelayCommand(_=>GenerateProgram(),_=>CanGenerate());
    }

    void LoadData()
    {
        foreach(var e in _dataService.GetAllEmployees()) Employees.Add(e);
        foreach(var d in _dataService.GetAllDepartments()) Departments.Add(d);
        foreach(var p in _dataService.GetAllPositions()) Positions.Add(p);
    }

    void LoadModules()
    {
        AvailableModules.Clear();
        if(SelectedPosition!=null)
        {
            // Фильтруем модули по должности
            var all = _dataService.GetAllModules();
            var related = all.Where(m=>m.Status == ModuleStatus.ПринятВРаботу && m.Positions.Any(pos=>pos.Id==SelectedPosition.Id));
            foreach(var m in related) AvailableModules.Add(m);
        }
    }

    bool CanGenerate()
    {
        return SelectedEmployee!=null && SelectedDepartment!=null && SelectedPosition!=null && SelectedModules.Any();
    }

    void GenerateProgram()
    {
        // Сформировать XLSX, отправить по почте и сохранить локально
        var filePath = $"C:\\AdaptationPrograms\\{SelectedDepartment.Name}_{SelectedPosition.Name}_{SelectedEmployee.FullName}_{System.DateTime.Now:yyyyMMdd}.xlsx";
        var excel = new ExcelExportService();
        excel.ExportAdaptationProgram(filePath,SelectedEmployee,SelectedDepartment,SelectedPosition,SelectedModules.ToList());
        _dataService.NotifyUsersByEmail(new[]{SelectedEmployee.FullName+"@mail.com"},"Программа адаптации","Прикреплен XLSX",filePath);
    }
}
