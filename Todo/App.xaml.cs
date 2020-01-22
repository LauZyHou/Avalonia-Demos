using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Todo._VMs;
using Todo._Vs;
using Todo.Services;

namespace Todo
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Database database = new Database();

                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindow_VM(database),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
