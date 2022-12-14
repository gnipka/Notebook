using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels
{
    internal class KeyboardViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Constructor

        public KeyboardViewModel()
        {
            LeftBord = 3;
            RightBord = 10;
            CountRepeat = 5;
        }
        #endregion

        #region Variables
        private string _phrase;
        private string _phraseChecker;
        private int _leftBord; 
        private int _rightBord;
        private int _countRepeat;
        private bool _run;
        private Stopwatch _sw;
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
                _sw = new Stopwatch();
                while (_run)
                {
                    _sw.Start();
                }
                _sw.Stop();
            });
        }
    }
}
