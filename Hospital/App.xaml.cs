using Hospital.ViewModel;
using System.Windows;

namespace Hospital
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow MainView;
        private MainVM _mainVM;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainView = new MainWindow();
            _mainVM = new MainVM(new DialogService.DialogService());
            MainView.DataContext = _mainVM;
            MainWindow.ShowDialog();
        }
    }
}
