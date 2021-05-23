using System.Windows;
using WpfMvvmCrud.ViewModel;

namespace WpfMvvmCrud
{
    public partial class FuncionariosWindow : Window
    {
        public FuncionariosWindow()
        {
            InitializeComponent();
            DataContext = new FuncionariosViewModel();
        }
    }
}