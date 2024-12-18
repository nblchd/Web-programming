namespace lab6.Models;

public enum ModuleStatus { Новый, Черновик, НаСогласовании, ПринятВРаботу, Архив }

public class AdaptationModule
{
    public int Id { get; set; }
    public string CodeName { get; set; } // номер приказа + рабочее наименование
    public string Title { get; set; }
    public List<Position> Positions { get; set; } = new();
    public List<ModuleEvent> Events { get; set; } = new();
    public List<ModuleMaterial> Materials { get; set; } = new();
    public List<Developer> Developers { get; set; } = new();
    public List<Approver> Approvers { get; set; } = new();
    public ModuleStatus Status { get; set; } = ModuleStatus.Новый;
    public DateTime DueDate { get; set; }
    public string AddedBy { get; set; }
    public DateTime AddedAt { get; set; }

    public List<AdaptationModule> Prerequisites { get; set; } = new(); // Ограничения по прохождению
    public bool IsEditingAllowed => Status == ModuleStatus.Новый || Status == ModuleStatus.Черновик;
}