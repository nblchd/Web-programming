namespace lab6.ViewModels;
using lab6.Models;
using lab6.Services;
using System.Collections.ObjectModel;

public class AnalysisViewModel : ViewModelBase
{
    private readonly IDataService _dataService;
    // Фильтры
    public ObservableCollection<Department> Departments {get;set;} = new();
    public ObservableCollection<Position> Positions {get;set;} = new();

    private Department _filterDept;
    public Department FilterDept {get=>_filterDept;set{_filterDept=value;OnPropertyChanged();Refresh();}}
    private Position _filterPos;
    public Position FilterPos {get=>_filterPos;set{_filterPos=value;OnPropertyChanged();Refresh();}}

    public ObservableCollection<AdaptationModule> ReportData {get;set;} = new();
    public AnalysisViewModel(IDataService dataService)
    {
        _dataService=dataService;
        foreach(var d in dataService.GetAllDepartments()) Departments.Add(d);
        foreach(var p in dataService.GetAllPositions()) Positions.Add(p);
        Refresh();
    }

    private void Refresh()
    {
        // Пример - просто все модули, без аналитики
        ReportData.Clear();
        var all = _dataService.GetAllModules();
        // Применяем фильтры...
        foreach(var m in all)
            ReportData.Add(m);
    }
}
