namespace lab6.Models;

public class ModuleMaterial
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FilePathOrUrl { get; set; }
    public string FileExtension { get; set; }
    public long FileSizeBytes { get; set; }
    public string AddedBy { get; set; }
    public DateTime AddedAt { get; set; }
}