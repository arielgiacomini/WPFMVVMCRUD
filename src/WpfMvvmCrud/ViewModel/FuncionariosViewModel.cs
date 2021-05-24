using System;
using System.Collections.ObjectModel;
using System.Linq;
using WpfMvvmCrud.Model;

namespace WpfMvvmCrud.ViewModel
{
    public class FuncionariosViewModel : BaseNotifyPropertyChanged
    {
        public ObservableCollection<Funcionario> Funcionarios { get; private set; }

        private Funcionario _funcionarioSelecionado;

        public DeletarCommand Deletar { get; private set; } = new DeletarCommand();

        public NovoCommand Novo { get; private set; } = new NovoCommand();

        public Funcionario FuncionarioSelecionado
        {
            get { return _funcionarioSelecionado; }
            set
            {
                SetField(ref _funcionarioSelecionado, value);
                Deletar.RaiseCanExecuteChanged();
            }
        }

        public FuncionariosViewModel()
        {
            Funcionarios = new ObservableCollection<Funcionario>
            {
                new Funcionario()
                {
                    Id = 1,
                    Nome = "Ariel",
                    Sobrenome = "Giacomini",
                    DataNascimento = new DateTime(1995, 03, 15),
                    Sexo = Sexo.Masculino,
                    EstadoCivil = EstadoCivil.Casado,
                    DataAdmissao = new DateTime(2021, 06, 07)
                }
            };

            FuncionarioSelecionado = Funcionarios.FirstOrDefault();
        }

        public class DeletarCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                var viewModel = parameter as FuncionariosViewModel;
                return viewModel != null && viewModel.FuncionarioSelecionado != null;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (FuncionariosViewModel)parameter;
                viewModel.Funcionarios.Remove(viewModel.FuncionarioSelecionado);
                viewModel.FuncionarioSelecionado = viewModel.Funcionarios.FirstOrDefault();
            }
        }

        public class NovoCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                return parameter is FuncionariosViewModel;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (FuncionariosViewModel)parameter;
                var funcionario = new Model.Funcionario();
                var maxId = 0;
                if (viewModel.Funcionarios.Any())
                {
                    maxId = viewModel.Funcionarios.Max(f => f.Id);
                }
                funcionario.Id = maxId + 1;

                var fw = new FuncionarioWindow();
                fw.DataContext = funcionario;
                fw.ShowDialog();

                if (fw.DialogResult.HasValue && fw.DialogResult.Value)
                {
                    viewModel.Funcionarios.Add(funcionario);
                    viewModel.FuncionarioSelecionado = funcionario;
                }
            }
        }
    }
}