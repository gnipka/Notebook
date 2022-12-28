using Microsoft.Win32;
using Notebook.Data.Abstract;
using Notebook.Domain;
using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region Variables

    private readonly User _user;
    private readonly IRepository<User> _userRepository;
    private readonly ApplicationContext _context;
    private readonly Window _thisWindow;
    private string _image;
    private string _userNote;

    private string _phrase = "";
    private string _phraseChecker;
    private int _leftBord = 3;
    private int _rightBord = 10;
    private int _countRepeat = 5;
    private bool _run;
    private bool _readOnly = true;
    private Stopwatch _sw;
    private long _time;
    private char _currentCharPhrase;
    private int _counterChar;
    private int _counterPhrase;
    private string _formatterPhrase;
    private List<Cell> _table = new List<Cell>();
    private int _errorRate = 30;
    private bool _addKeyboard = false;
    private List<KeyboardPoint> _keyboardPoints = new List<KeyboardPoint>();
    private List<Result> _results = new List<Result>();
    private List<Result> _resultsOld = new List<Result>();

    private IEnumerable<XYPoint> _arrayOfPoints;
    private int _deltaPixels;
    private int _amountOfAttempt;
    private int _amountOfSymbol;

    #endregion

    #region Constructors

    public MainWindowViewModel(User user, IRepository<User> userRepository, ApplicationContext context, Window thisWindow)
    {
        _user = user;
        _userRepository = userRepository;
        _context = context;
        _thisWindow = thisWindow;
        Image = user.PathToImage;
        UserNote = user.Note.NoteText;
        DeltaPixels = user.DeltaPixels;
        AmountOfAttempt = user.AmountOfAttempt;

        if (user.HasKeyboard)
        {
            if (user.KeyboardPoints != null)
            {
                _keyboardPoints = user.KeyboardPoints.ToList();
                for (int i = 0; i < _keyboardPoints.Count; i++)
                {
                    _resultsOld.Add(new Result { Point = _keyboardPoints[i], Time = _keyboardPoints[i].Time });

                    if (_keyboardPoints[i].LeftLimit > _keyboardPoints[i].Time || _keyboardPoints[i].RightLimit < _keyboardPoints[i].Time)
                    {
                        _resultsOld.Last().ResultBool = false;
                        _resultsOld.Last().ResultStirng = "Запрещен";
                    }
                    else
                    {
                        _resultsOld.Last().ResultBool = true;
                        _resultsOld.Last().ResultStirng = "Разрешен";
                    }
                }
            }
            Phrase = user.CodePhrase;
            ErrorRate = user.ErrorRate;
            AmountOfSymbol = user.AmountOfSymbol;
        }
        else
        {
            ErrorRate = 30;
            AmountOfSymbol = 50;
        }
    }

    #endregion

    #region Properties

    public string Image
    {
        get => _image;
        set
        {
            _image = value;
            OnPropertyChanged();
        }
    }

    public IEnumerable<XYPoint> ArrayOfPoints
    {
        get => _arrayOfPoints;
        set
        {
            _arrayOfPoints = value;
            OnPropertyChanged();
        }
    }

    public string UserNote
    {
        get => _userNote;
        set
        {
            _userNote = value;
            OnPropertyChanged();
        }
    }

    public string Phrase
    {
        get { return _phrase; }
        set
        {
            _phrase = value;
            OnPropertyChanged();
        }
    }

    public int ErrorRate
    {
        get { return _errorRate; }
        set
        {
            _errorRate = value;
            OnPropertyChanged();
        }
    }

    public string PhraseChecker
    {
        get { return _phraseChecker; }
        set
        {
            _phraseChecker = value;

            if (_phraseChecker != "")
            {

                if (_phraseChecker.Substring(_phraseChecker.Length - 1) != "\n" && _phraseChecker.Substring(_phraseChecker.Length - 1) != "\r")
                {

                    if (_phraseChecker[_phraseChecker.Length - 1] == _currentCharPhrase)
                    {
                        if (_table.Count() == 0)
                            _table.Add(new Cell { Symbol = _phraseChecker[_phraseChecker.Length - 1], Time = _sw.ElapsedMilliseconds, Number = _counterChar });
                        else
                        {
                            var table = _table.Last();
                            _table.Add(new Cell { Symbol = _phraseChecker[_phraseChecker.Length - 1], Time = _sw.ElapsedMilliseconds - table.Time, Number = _counterChar });
                        }
                        if (_counterChar == _formatterPhrase.Length - 1)
                        {
                            if (_counterPhrase == CountRepeat)
                            {
                                _run = false;
                                _addKeyboard = true;
                                _keyboardPoints = new List<KeyboardPoint>();

                                for (int i = 0; i < Phrase.Length; i++)
                                {
                                    var times = _table.Where(x => x.Number == i).ToList();
                                    times.Remove(times.First(x => x.Time == times.Max(x => x.Time)));
                                    times.Remove(times.First(x => x.Time == times.Min(x => x.Time)));
                                    var mean = times.Average(x => x.Time);

                                    var keyboardPoint = new KeyboardPoint
                                    {
                                        Symbol = Phrase[i],
                                        Time = mean,
                                        LeftLimit = mean - mean * ErrorRate / 100,
                                        RightLimit = mean + mean * ErrorRate / 100,
                                        NumberOfChar = i,
                                        User = _user,
                                        UserId = _user.Id
                                    };

                                    _keyboardPoints.Add(keyboardPoint);

                                    _results.Add(new Result { Point = keyboardPoint, Time = keyboardPoint.Time });

                                    if (keyboardPoint.LeftLimit > keyboardPoint.Time || keyboardPoint.RightLimit < keyboardPoint.Time)
                                    {
                                        _results.Last().ResultBool = false;
                                        _results.Last().ResultStirng = "Запрещен";
                                    }
                                    else
                                    {
                                        _results.Last().ResultBool = true;
                                        _results.Last().ResultStirng = "Разрешен";
                                    }

                                }
                                AmountOfSymbol = 50;
                                MessageBox.Show("Ввод законечен");

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

    public int DeltaPixels
    {
        get => _deltaPixels;
        set
        {
            _deltaPixels = value;
            OnPropertyChanged();
        }
    }

    public int AmountOfAttempt
    {
        get => _amountOfAttempt;
        set
        {
            _amountOfAttempt = value;
            OnPropertyChanged();
        }
    }

    public int AmountOfSymbol
    {
        get => _amountOfSymbol;
        set
        {
            if (value >= 50 && value <= 100)
            {
                _amountOfSymbol = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion

    #region Commands

    public RelayCommand SaveNoteCommand
    {
        get
        {
            return new RelayCommand(async command =>
            {
                _user.Note.NoteText = _userNote;
                _user.Note.DateUpdated = DateTime.Now;

                await _userRepository.SaveAsync(_user);

                MessageBox.Show("Записи сохранены");

            });
        }
    }

    public RelayCommand ChooseImage
    {
        get
        {
            return new RelayCommand(command =>
            {
                var file = new OpenFileDialog();
                file.Filter = "Images|*.png;*.jpg|All files (*.*)|*.*";
                if ((bool)file.ShowDialog())
                {
                    Image = file.FileName;
                }

            });
        }
    }

    public RelayCommand SaveCommand
    {
        get
        {
            return new RelayCommand(async command =>
            {
                if (MessageBox.Show(
                        "Вы уверены, что хотите перезаписать все данные о графическом ключе для данного пользователя",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (ArrayOfPoints.Count() > 0)
                    {
                        //удаляем уже существующие точки графического ключа у данного пользователя
                        var graphKeys = _context.GraphKeyPoints.Where(x => x.UserId == _user.Id).ToList();
                        foreach (var graphKey in graphKeys)
                        {
                            _context.GraphKeyPoints.Remove(graphKey);
                        }

                        _user.DeltaPixels = DeltaPixels;
                        _user.AmountOfAttempt = AmountOfAttempt;
                        _user.PathToImage = Image;
                        _user.HasGraphKey = true;
                        _user.GraphKeyPoints = new List<GraphKeyPoint>();
                        var i = 0;
                        foreach (var point in ArrayOfPoints)
                        {
                            var graphKeyPoint = new GraphKeyPoint
                            {
                                NumberOfPoint = i,
                                User = _user,
                                UserId = _user.Id,
                                XValue = point.X,
                                YValue = point.Y,
                            };
                            i++;
                            _user.GraphKeyPoints.Add(graphKeyPoint);
                        }

                        await _userRepository.SaveAsync(_user);

                        MessageBox.Show("Графический ключ установлен");
                    }
                    else
                    {
                        MessageBox.Show("Вы не ввели графический ключ");
                    }
                }
            });
        }
    }

    public RelayCommand LogoutCommand
    {
        get
        {
            return new RelayCommand(command =>
            {
                var window = new AuthWindow();
                var vm = new AuthViewModel(_userRepository, _context, window);
                window.DataContext = vm;
                window.Show();

                _thisWindow.Close();
            });
        }
    }

    private RelayCommand _checkPhrase;
    public RelayCommand CheckPhrase
    {
        get
        {
            return _checkPhrase ??= new RelayCommand(async x =>
            {
                if (Phrase != "")
                {
                    Time = 0;
                    PhraseChecker = "";
                    _counterChar = 0;
                    _counterPhrase = 1;
                    _currentCharPhrase = Phrase[_counterChar]; // берем первый символ фразы
                    _run = true; // ставим метку для таймера
                    _formatterPhrase = Phrase;
                    ReadOnly = false;
                    _results = new List<Result>();
                    StartTimer(); // запускаем таймер
                }
                else
                {
                    MessageBox.Show("Введите фразу");
                }
            });
        }
    }

    private RelayCommand _saveKeyboard;
    public RelayCommand SaveKeyboard
    {
        get
        {
            return _saveKeyboard ??= new RelayCommand(async x =>
            {
                //удаляем уже существующие точки графического ключа у данного пользователя
                if (_addKeyboard)
                {
                    var keyboardPred = _context.KeyboardPoints.Where(x => x.UserId == _user.Id).ToList();

                    foreach (var item in keyboardPred)
                    {

                        _context.KeyboardPoints.Remove(item);
                    }
                    _keyboardPoints = new List<KeyboardPoint>();
                    _user.CodePhrase = Phrase;
                    _user.HasKeyboard = true;
                    _user.KeyboardPoints = new List<KeyboardPoint>();
                    _user.ErrorRate = ErrorRate;
                    _user.AmountOfSymbol = AmountOfSymbol;

                    for (int i = 0; i < Phrase.Length; i++)
                    {
                        var times = _table.Where(x => x.Number == i).ToList();
                        times.Remove(times.First(x => x.Time == times.Max(x => x.Time)));
                        times.Remove(times.First(x => x.Time == times.Min(x => x.Time)));
                        var mean = times.Average(x => x.Time);

                        var keyboardPoint = new KeyboardPoint
                        {
                            Symbol = Phrase[i],
                            Time = (long)mean,
                            LeftLimit = (long)mean - (long)mean * ErrorRate / 100,
                            RightLimit = (long)mean + (long)mean * ErrorRate / 100,
                            NumberOfChar = i,
                            User = _user,
                            UserId = _user.Id
                        };

                        _user.KeyboardPoints.Add(keyboardPoint);

                    }

                    await _userRepository.SaveAsync(_user);

                    MessageBox.Show("Вход по клавиатурному подчерку добавлен");
                }
                else
                {
                    if (_user.HasKeyboard)
                    {
                        if (MessageBox.Show(
                        "Вы не ввели данные для добавления клавиатурного подчерка. Перезаписать настройки существующего?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            if (_user.CodePhrase == Phrase)
                            {
                                _user.ErrorRate = ErrorRate;
                                _user.AmountOfSymbol = AmountOfSymbol;
                                await _userRepository.SaveAsync(_user);
                            }
                            else
                                MessageBox.Show("Кодовая фраза не совпадает с ранее добавленной, для изменения настроек клавиатурного подчерка, введите корректную кодовую фразу");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данные для сохранения отсутствуют");
                    }
                }
            });
        }
    }

    public RelayCommand Plot
    {
        get
        {
            return new RelayCommand(command =>
            {
                if (_addKeyboard)
                {
                    var windowReport = new ReportWindow();
                    var vmReport = new ReportViewModel(_results, "Разрешен", false, _user);
                    windowReport.DataContext = vmReport;
                    windowReport.Show();
                }
                else if(_resultsOld.Count != 0)
                {
                    var windowReport = new ReportWindow();
                    var vmReport = new ReportViewModel(_resultsOld, "Разрешен", false, _user);
                    windowReport.DataContext = vmReport;
                    windowReport.Show();
                }
                else
                    MessageBox.Show("Данные для построения графика отсутствуют");
            });
        }
    }
    #endregion

    #region Functions

    async void StartTimer()
    {
        await Task.Run(() =>
        {
            Sw = Stopwatch.StartNew();
            while (_run)
            {
                Time = _sw.ElapsedMilliseconds / 1000;
            }
            Sw.Stop();
        });
    }

    #endregion
}