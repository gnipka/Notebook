using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels
{
    internal class AuthViewModel : ViewModelBase
    {
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
    }
}
