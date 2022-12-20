using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore.Metadata;
using Notebook.Data.Abstract;
using Notebook.Domain;
using Notebook.Models;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels
{
    internal class AuthViewModel : ViewModelBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly ApplicationContext _context;

        #region Variables

        private string _login;
        private string _pass;

        #endregion

        #region Properties

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Pass
        {
            get { return _pass; }
            set
            {
                _pass = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public AuthViewModel(IRepository<User> userRepository, ApplicationContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        #region Commands

        public RelayCommand AuthorizeCommand
        {
            get
            {
                return new RelayCommand(async command =>
                {
                    var user = await _userRepository.VerifyUserAsync(Login, Pass);
                    if (user != null)
                    {
                        if (user.HasGraphKey)
                        {
                            var window = new GraphKeyWindow();
                            var vm = new GraphKeyWindowViewModel(user, _userRepository, _context, window);
                            window.DataContext = vm;
                            window.Show();
                        }
                        else
                        {
                            var window = new MainWindow();
                            var vm = new MainWindowViewModel(user, _userRepository, _context);
                            window.DataContext = vm;
                            window.Show();
                        }
                        
                        Application.Current.MainWindow.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        //Авторизация не пройдена
                    }
                });
            }
        }

        #endregion
    }
}
