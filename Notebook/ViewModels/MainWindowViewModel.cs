using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Notebook.Data.Abstract;
using Notebook.Domain;
using Notebook.Models;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region Variables

    private readonly User _user;
    private readonly IRepository<User> _userRepository;
    private readonly ApplicationContext _context;
    private string _image;

    private IEnumerable<XYPoint> _arrayOfPoints;
    
    #endregion

    #region Constructors

    public MainWindowViewModel(User user, IRepository<User> userRepository, ApplicationContext context)
    {
        _user = user;
        _userRepository = userRepository;
        _context = context;
        Image = user.PathToImage;
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

    #endregion

    #region Commands

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
                //удаляем уже существующие точки графического ключа у данного пользователя
                var graphKeys = _context.GraphKeyPoints.Where(x => x.UserId == _user.Id).ToList();
                foreach (var graphKey in graphKeys)
                {
                    _context.GraphKeyPoints.Remove(graphKey);
                }

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
                        Delta = 10, // пока пусть 10)
                        XValue = point.X,
                        YValue = point.Y,
                    };
                    i++;
                    _user.GraphKeyPoints.Add(graphKeyPoint);
                }

                await _userRepository.SaveAsync(_user);

                MessageBox.Show("Графический ключ установлен");
            });
        }
    }

    #endregion

    #region Functions



    #endregion
}