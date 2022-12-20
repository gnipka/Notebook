using Notebook.ViewModels;
using System.Windows;
using Notebook.Data.Abstract;
using Notebook.Models;
using System.Windows.Controls;

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            //это позволяет передать пароль во viewModel
            ((dynamic)this.DataContext).Pass = ((PasswordBox)sender).Password;
        }
    }
}
