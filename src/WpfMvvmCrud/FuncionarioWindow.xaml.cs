using System;
using System.Linq;
using System.Windows;

namespace WpfMvvmCrud
{
    public partial class FuncionarioWindow : Window
    {
        public FuncionarioWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SexoComboBox.ItemsSource = Enum.GetValues(typeof(Model.Sexo)).Cast<Model.Sexo>();
            EstadoCivilComboBox.ItemsSource = Enum.GetValues(typeof(Model.EstadoCivil)).Cast<Model.EstadoCivil>();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}