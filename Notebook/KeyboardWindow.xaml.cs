using Notebook.ViewModels;
using System.Windows;

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для KeyboardWindow.xaml
    /// </summary>
    public partial class KeyboardWindow : Window
    {
        public KeyboardWindow()
        {
            InitializeComponent();
            DataContext = new KeyboardViewModel();
        }
    }
}
