namespace lab6.ViewModels;

using lab6.Models;

public class ModuleDetailViewModel : ViewModelBase
{
    public AdaptationModule Module { get; set; }
    public ModuleDetailViewModel(AdaptationModule module)
    {
        Module = module;
    }
}