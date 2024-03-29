﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Notebook.Data.Abstract;
using Notebook.Domain;
using Notebook.Models;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels;

public class RegistrationWindowViewModel : ViewModelBase
{

    #region Variables

    private readonly IRepository<User> _userRepository;
    private readonly ApplicationContext _context;
    private readonly Window _thisWindow;
    private string _login;
    private string _password;

    #endregion

    #region Constructors

    public RegistrationWindowViewModel(IRepository<User> userRepository, ApplicationContext context, Window thisWindow)
    {
        _userRepository = userRepository;
        _context = context;
        _thisWindow = thisWindow;
    }

    #endregion

    #region Properties

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged();
        }
    }

    public string Pass
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Commands

    public RelayCommand RegistrationCommand
    {
        get
        {
            return new RelayCommand(async command =>
            {
                if (string.IsNullOrWhiteSpace(Login))
                {
                    MessageBox.Show("Вы не ввели логин");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Pass))
                {
                    MessageBox.Show("Вы не ввели пароль");
                    return;
                }

                if (await _userRepository.GetByLoginAsync(Login) != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                    return;
                }

                if (!Regex.IsMatch(Login, "^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Логин должен содержать только буквы латинского алфавита и/или цифры");
                    return;
                }

                if (!Regex.IsMatch(Pass, "^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Пароль должен содержать только буквы латинского алфавита и/или цифры");
                    return;
                }

                var note = new Note
                {
                    NoteText = "",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                };

                await _context.Notes.AddAsync(note);
                await _context.SaveChangesAsync();
                var dateNow = DateTime.Now;
                var user = new User
                {
                    Username = Login,
                    Password = Cipher(Pass, GenerateKey(dateNow.Ticks)),
                    DateRegister = dateNow,
                    GraphKeyPoints = null,
                    HasGraphKey = false,
                    PathToImage = "",
                    DeltaPixels = 0,
                    AmountOfAttempt = 1,
                    NoteId = _context.Notes.First(x => x == note).Id,
                    HasKeyboard = false,
                    KeyboardPoints = null,
                    CodePhrase = "",
                
                };

                await _userRepository.SaveAsync(user);

                user.Note = note;

                var window = new MainWindow();
                var vm = new MainWindowViewModel(user, _userRepository, _context, window);
                window.DataContext = vm;
                window.Show();

                _thisWindow.Close();
            });
        }
    }

    #endregion

    #region Functions


    //генератор повторений пароля
    private string GetRepeatKey(string s, int n)
    {
        var r = s;
        while (r.Length < n)
        {
            r += r;
        }

        return r.Substring(0, n);
    }

    //метод шифрования/дешифровки
    private string Cipher(string text, string secretKey)
    {
        var currentKey = GetRepeatKey(secretKey, text.Length);
        var res = string.Empty;
        for (var i = 0; i < text.Length; i++)
        {
            res += ((char)(text[i] ^ currentKey[i])).ToString();
        }

        return res;
    }

    //генерация ключа для пользователя в зависимости от времени регистрации
    private string GenerateKey(long ticks)
    {
        var alphabet = new List<string>
        {
            "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й",
            "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х",
            "ц", "ч", "ш", "щ", "ь", "ы", "ъ", "э", "ю", "я"
        };

        var key = new StringBuilder();
        key.Append(alphabet[(int)(ticks % 31)]);
        key.Append(alphabet[(int)(ticks % 32)]);
        key.Append(alphabet[(int)(ticks % 33)]);

        return key.ToString();
    }

    #endregion
}