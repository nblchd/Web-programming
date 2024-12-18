namespace lab6.ViewModels;

using lab6.Models;
using lab6.Services;
using System.Collections.ObjectModel;
using System.Linq;

public class ModulesViewModel : ViewModelBase
{
    private readonly IDataService _dataService;

    public ObservableCollection<AdaptationModule> Modules { get; set; } = new();
    public string SearchText { get; set; }
    private ModuleStatus? _filterStatus;
    public ModuleStatus? FilterStatus 
    { 
        get=>_filterStatus; 
        set { _filterStatus=value; OnPropertyChanged(); RefreshModules(); } 
    }

    public RelayCommand RefreshCommand { get; set; }
    public RelayCommand CreateModuleCommand { get; set; }

    public ModulesViewModel(IDataService dataService)
    {
        _dataService = dataService;
        RefreshCommand = new RelayCommand(_=>RefreshModules());
        CreateModuleCommand = new RelayCommand(_=>CreateModule());
        RefreshModules();
    }

    private void RefreshModules()
    {
        Modules.Clear();
        var all = _dataService.GetAllModules();

        var filtered = all.Where(m=>{
            bool statusOk = !FilterStatus.HasValue || m.Status == FilterStatus.Value;
            bool searchOk = string.IsNullOrEmpty(SearchText) || m.Title.Contains(SearchText) || m.CodeName.Contains(SearchText);
            return statusOk && searchOk;
        });

        foreach(var m in filtered) Modules.Add(m);
    }

    private void CreateModule()
    {
        // Открываем окно создания модуля
        var vm = new CreateModuleViewModel(_dataService);
        var win = new CreateModuleView();
        win.DataContext=vm;
        win.ShowDialog();
        RefreshModules();
    }
}
