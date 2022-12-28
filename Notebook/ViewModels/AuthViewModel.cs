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
        #region Variables

        private User _login;
        private string _pass;
        private readonly IRepository<User> _userRepository;
        private readonly ApplicationContext _context;
        private readonly Window _authWindow;

        private List<User> _usersList;

        #endregion

        #region Properties

        public User Login
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

        public List<User> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public AuthViewModel(IRepository<User> userRepository, ApplicationContext context, Window authWindow)
        {
            _userRepository = userRepository;
            _context = context;
            _authWindow = authWindow;
            UsersList = userRepository.GetAll().ToList();
        }

        #region Commands

        public RelayCommand AuthorizeCommand
        {
            get
            {
                return new RelayCommand(async command =>
                {
                    if (string.IsNullOrWhiteSpace(Login.Username))
                    {
                        MessageBox.Show("Вы не ввели логин");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(Pass))
                    {
                        MessageBox.Show("Вы не ввели пароль");
                        return;
                    }

                    var user = await _userRepository.VerifyUserAsync(Login.Username, Pass);
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
                            var vm = new MainWindowViewModel(user, _userRepository, _context, window);
                            window.DataContext = vm;
                            window.Show();
                        }

                        _authWindow.Close();
                    }
                    else
                    {
                        //Авторизация не пройдена
                        MessageBox.Show("Логин и/или пароль указаны неверно");
                    }
                });
            }
        }

        public RelayCommand ForgotPassword
        {
            get
            {
                return new RelayCommand(async command =>
                {
                    if (!string.IsNullOrWhiteSpace(Login.Username))
                    {
                        var user = await _userRepository.GetByLoginAsync(Login.Username);
                        if (user != null)
                        {
                            if (user.HasKeyboard)
                            {
                                var window = new KeyboardWindow();
                                var vm = new KeyboardViewModel(Login.Username, user, _userRepository, _context, window);
                                window.DataContext = vm;
                                window.Show();

                                _authWindow.Close();
                            }
                            else
                                MessageBox.Show("Вход по клавиатрному подчерку не добавлен");
                        }
                        else
                            MessageBox.Show("Логин указан неверно");
                    }
                    else
                    {
                        MessageBox.Show("Укажите логин");
                    }

                });
            }
        }

        public RelayCommand RegistrationCommand
        {
            get
            {
                return new RelayCommand(command =>
                {
                    var window = new RegistrationWindow();
                    var vm = new RegistrationWindowViewModel(_userRepository, _context, window);
                    window.DataContext = vm;
                    window.Show();

                    _authWindow.Close();
                });
            }
        }

        public RelayCommand Help
        {
            get
            {
                return new RelayCommand(command =>
                {
                    var window = new HelpWindow();
                    window.Show();
                });
            }
        }
        #endregion
    }
}
