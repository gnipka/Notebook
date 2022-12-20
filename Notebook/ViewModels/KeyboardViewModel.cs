using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using Notebook.Models;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels
{
    class Cell
    {
        public char Symbol { get; set; }
        public long Time { get; set; }
    }

    internal class KeyboardViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly string _login;
        private readonly User _user;

        #region Constructor

        public KeyboardViewModel(string login) // логин пользователя для которого вводим клавиатурный почерк
        {
            _login = login;
            LeftBord = 3;
            RightBord = 10;
            CountRepeat = 5;
            ReadOnly = true;
        }
        #endregion

        #region Variables
        private string _phrase;
        private string _phraseChecker;
        private int _leftBord; 
        private int _rightBord;
        private int _countRepeat;
        private bool _run;
        private bool _readOnly;
        private Stopwatch _sw;
        private long _time;
        private char _currentCharPhrase;
        private int _counterChar;
        private int _counterPhrase;
        private string _formatterPhrase;
        private List<Cell> _table = new List<Cell>();
        #endregion

        #region Properties
        public string Phrase
        {
            get { return _phrase; }
            set
            {
                _phrase = value;
                OnPropertyChanged();
            }
        }

        public string PhraseChecker
        {
            get { return _phraseChecker; }
            set
            {
                _phraseChecker = value;


                if (_phraseChecker.Substring(_phraseChecker.Length - 1) != "\n" && _phraseChecker.Substring(_phraseChecker.Length - 1) != "\r")
                {

                    if (_phraseChecker[_phraseChecker.Length - 1] == _currentCharPhrase)
                    {
                        _table.Add(new Cell { Symbol = _phraseChecker[_phraseChecker.Length - 1], Time = _sw.ElapsedMilliseconds });
                        if (_counterChar == _formatterPhrase.Length - 1)
                        {
                            if (_counterPhrase == CountRepeat)
                            {
                                _run = false;
                                // вызываем окно ежедневника
                                MessageBox.Show("OK");

                            }
                            else
                            {
                                _counterChar = 0;
                                _currentCharPhrase = _formatterPhrase[_counterChar];
                                _counterPhrase++;
                            }
                        }
                        else
                        {
                            _counterChar++;
                            _currentCharPhrase = _formatterPhrase[_counterChar];
                        }

                    }
                    else
                    {
                        _run = false;
                        Time = 0;
                        ReadOnly = true;
                        _phraseChecker = String.Empty;
                        MessageBox.Show("Ошибка при вводе фразы. Необходимо начать заново :(");
                    }
                }

                OnPropertyChanged();
            }
        }

        public Stopwatch Sw
        {
            get { return _sw; }
            set
            {
                _sw = value;                
                OnPropertyChanged();
            }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                OnPropertyChanged();
            }
        }

        public long Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        public int LeftBord
        {
            get { return _leftBord; }
            set
            {
                _leftBord = value;
                OnPropertyChanged();
            }
        }

        public int RightBord
        {
            get { return _rightBord; }
            set
            {
                _rightBord = value;
                OnPropertyChanged();
            }
        }
        
        public int CountRepeat
        {
            get { return _countRepeat; }
            set
            {
                _countRepeat = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ExceptionRule
        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get 
            {
                string error = String.Empty;

                switch (columnName)
                {
                    case "CountRepeat":
                        if (CountRepeat > RightBord || CountRepeat < LeftBord)
                            error = $"Число повторов должно быть в диапазоне [{LeftBord};{RightBord}]";
                        break;
                }
                return error;
            }
        }
        #endregion

        async void StartTimer()
        {
            await Task.Run(() =>
            {
                Sw = Stopwatch.StartNew();
                while (_run) {
                    Time = _sw.ElapsedMilliseconds / 1000;
                }
                Sw.Stop();
            });
        }

        private RelayCommand _checkPhrase;
        public RelayCommand CheckPhrase
        {
            get
            {
                return _checkPhrase ??= new RelayCommand(async x =>
                {
                    // добавить проверку фразы из бд
                    _counterChar = 0;
                    _counterPhrase = 1;
                    _currentCharPhrase = Phrase[_counterChar]; // берем первый символ фразы
                    _run = true; // ставим метку для таймера
                    _formatterPhrase = Phrase;
                    ReadOnly = false;
                    StartTimer(); // запускаем таймер
                });
            }
        }
    }
}
