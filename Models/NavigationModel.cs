using Lab02.Views;
using Lab02.Windows;

namespace Lab02.Models
{
    class NavigationModel
    {
        private ContentWindow _contentWindow;
        private LoginView _loginView;

        public NavigationModel(ContentWindow contentWindow, Storage storage)
        {
            _contentWindow = contentWindow;
            _loginView = new LoginView(storage);
        }
        public void Navigate()
        {
            _contentWindow.ContentControl.Content = _loginView;
        }
    }
}