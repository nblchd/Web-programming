using lab6.Services;
using lab6.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ModulesViewModel ModulesVM {get;}
    public ConstructorViewModel ConstructorVM {get;}
    public AnalysisViewModel AnalysisVM {get;}

    public MainWindowViewModel()
    {
        var ds = new MockDataService();
        ModulesVM = new ModulesViewModel(ds);
        ConstructorVM = new ConstructorViewModel(ds);
        AnalysisVM = new AnalysisViewModel(ds);
    }
}