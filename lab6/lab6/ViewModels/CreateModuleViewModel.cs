namespace lab6.ViewModels;

using lab6.Models;
using lab6.Services;
using System;
using System.Collections.ObjectModel;

public class CreateModuleViewModel : ViewModelBase
{
    private readonly IDataService _dataService;
    public string CodeName {get;set;}
    public string Title {get;set;}
    public DateTime DueDate {get;set;}=DateTime.Now.AddDays(30);

    public ObservableCollection<Developer> Developers {get;set;} = new();
    public ObservableCollection<Approver> Approvers {get;set;} = new();
    public ObservableCollection<Position> Positions {get;set;} = new();

    public ObservableCollection<Developer> SelectedDevelopers {get;set;}=new();
    public ObservableCollection<Approver> SelectedApprovers {get;set;}=new();
    public Position SelectedPosition {get;set;}

    public RelayCommand SaveCommand {get;set;}

    public CreateModuleViewModel(IDataService ds)
    {
        _dataService=ds;
        // Загружаем тестовые данные для выбора...
        Developers.Add(new Developer{Id=1,FullName="Разработчик 1"});
        Developers.Add(new Developer{Id=2,FullName="Разработчик 2"});

        Approvers.Add(new Approver{Id=1,FullName="Согласовант 1"});
        Approvers.Add(new Approver{Id=2,FullName="Согласовант 2",IsMainApprover=true});

        foreach(var p in _dataService.GetAllPositions()) Positions.Add(p);

        SaveCommand=new RelayCommand(_=>Save());
    }

    void Save()
    {
        var module = new AdaptationModule
        {
            CodeName=CodeName,
            Title=Title,
            DueDate=DueDate,
            Status=ModuleStatus.Черновик,
            AddedBy="HR Specialist",
            AddedAt=DateTime.Now,
            Developers = new System.Collections.Generic.List<Developer>(SelectedDevelopers),
            Approvers = new System.Collections.Generic.List<Approver>(SelectedApprovers),
            Positions = SelectedPosition!=null?new System.Collections.Generic.List<Position>{SelectedPosition}:new System.Collections.Generic.List<Position>()
        };
        _dataService.AddModule(module);

        // Уведомить по почте
        var pdfService=new PdfService();
        var pdfPath=pdfService.GenerateModulePdf(module);
        _dataService.NotifyUsersByEmail(module.Developers.Select(d=>d.FullName+"@mail.com"),"Назначен модуль", "Добрый день, коллеги. Вы назначены разработчиком...",pdfPath);

        // Закрыть окно
        OnRequestClose?.Invoke();
    }

    public event Action OnRequestClose;
}
