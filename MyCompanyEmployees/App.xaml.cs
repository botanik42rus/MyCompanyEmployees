using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyCompanyEmployees
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ViewModel viewModel;
        MainWindow mn;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            viewModel = new ViewModel();
            mn = new MainWindow();
            mn.DataContext = viewModel;
            mn.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            viewModel.ViewModelSave();
            base.OnExit(e);
        }
    }
}
