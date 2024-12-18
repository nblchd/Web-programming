using System.Windows;
using lab6;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var mw = new MainWindow();
        mw.DataContext=new MainWindowViewModel();
        mw.Show();
    }
}