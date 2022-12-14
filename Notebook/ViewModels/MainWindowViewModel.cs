using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notebook.Data.Abstract;
using Notebook.Models;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    
    #region Variables

    private readonly IRepository<User> _userRepository;

    #endregion

    #region Constructors

    public MainWindowViewModel(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    #endregion

    #region Properties



    #endregion

    #region Commands



    #endregion

    #region Functions



    #endregion
}