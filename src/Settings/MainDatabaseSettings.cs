namespace SCurveProject.settings;

public class MainDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string UserCollection { get; set; } = null!;
    public string ProjectCollection { get; set; } = null!;
    public string ProjectTaskCollection { get; set; } = null!;
    public string MicroTaskCollection { get; set; } = null!;
    public string ProgressCollection { get; set; } = null!;
    public string NotificationCollection { get; set; } = null!;
}