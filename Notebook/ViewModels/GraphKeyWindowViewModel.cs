using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore.Metadata;
using Notebook.Data.Abstract;
using Notebook.Data.Implemetion;
using Notebook.Domain;
using Notebook.Models;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels;

public class GraphKeyWindowViewModel : ViewModelBase
{
    private readonly User _user;
    private readonly IRepository<User> _userRepository;
    private readonly ApplicationContext _context;
    private readonly Window _thisWindow;

    #region Variables

    private string _image;
    private List<XYPoint> _arrayOfPoints;
    public double _delta;

    #endregion

    #region Constructors

    public GraphKeyWindowViewModel(User user, IRepository<User> userRepository, ApplicationContext context, Window thisWindow)
    {
        _user = user;
        _userRepository = userRepository;
        _context = context;
        _thisWindow = thisWindow;
        //var uri = new Uri(user.PathToImage, UriKind.Relative);
        Image = user.PathToImage;
        _delta = 10;
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

    public List<XYPoint> ArrayOfPoints
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

    public RelayCommand LoginButton
    {
        get
        {
            return new RelayCommand(command =>
            {
                if (ArrayOfPoints.Count > 0)
                {
                    if (CheckGraphKeys())
                    {
                        var window = new MainWindow();
                        var vm = new MainWindowViewModel(_user, _userRepository, _context);
                        window.DataContext = vm;
                        window.Show();

                        _thisWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Графический ключ введен неверно!");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не ввели графический ключ");
                }
                
            });
        }
    }

    #endregion

    #region Functions

    /// <summary>
    /// Проверка введенного графического ключа на правильность, также учитывается порядок ввода
    /// </summary>
    /// <returns>true если ключ введен верно, false если неверно</returns>
    private bool CheckGraphKeys()
    {
        var userPoints =
            _user.GraphKeyPoints.Select(userGraphKeyPoint => new XYPoint(userGraphKeyPoint.NumberOfPoint ,userGraphKeyPoint.XValue, userGraphKeyPoint.YValue)).ToList();

        var i = 0;
        foreach (var userPoint in userPoints)
        {
            var minX = userPoint.X - _delta;
            var maxX = userPoint.X + _delta;

            var minY = userPoint.Y - _delta;
            var maxY = userPoint.Y + _delta;

            if (ArrayOfPoints.Count == userPoints.Count) // проверяем что точек ровно столько сколько надо
            {
                if (ArrayOfPoints[i].X < maxX && ArrayOfPoints[i].X > minX && ArrayOfPoints[i].Y < maxY &&
                    ArrayOfPoints[i].Y > minY && ArrayOfPoints[i].NumberOfPoint == userPoint.NumberOfPoint) // проверяем что они в допустимом диапазоне
                {
                    i++;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    #endregion
}