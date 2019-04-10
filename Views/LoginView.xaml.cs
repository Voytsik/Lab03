using Lab02.Models;
using Lab02.ViewModels;
using System.Windows.Controls;

namespace Lab02.Views
{
    public partial class LoginView : UserControl
    {
        private LoginViewModel _viewModel;

        public LoginView(Storage storage)
        {
            InitializeComponent();
            _viewModel = new LoginViewModel(storage);
            DataContext = _viewModel;
        }
    }
}