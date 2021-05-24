using System.Windows;
using WpfMvvmCrud.ViewModel;

namespace WpfMvvmCrud
{
    public partial class FuncionariosWindow : Window
    {
        public FuncionariosWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = new FuncionariosViewModel();
        }
    }
}