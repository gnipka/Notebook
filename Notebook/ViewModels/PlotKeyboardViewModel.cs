using LiveCharts;
using Notebook.Models;
using System;
using System.Collections.Generic;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels
{
    internal class PlotKeyboardViewModel : ViewModelBase
    {
        #region Constructors
        public PlotKeyboardViewModel(List<KeyboardPoint> keyboardPoints)
        {
            _keyboardPoints = keyboardPoints;

            for(int i = 0; i < keyboardPoints.Count; i++)
            {
                if (i == 0)
                {
                    Chart1.Add(keyboardPoints[i].RightLimit);
                    Chart2.Add(keyboardPoints[i].Time);
                    Chart3.Add(keyboardPoints[i].LeftLimit);
                    CharChart.Add(keyboardPoints[i].Symbol.ToString());
                }
                else
                {
                    Chart1.Add(keyboardPoints[i].RightLimit - keyboardPoints[i - 1].RightLimit);
                    Chart2.Add(keyboardPoints[i].Time - keyboardPoints[i - 1].Time);
                    Chart3.Add(keyboardPoints[i].LeftLimit - keyboardPoints[i - 1].LeftLimit);
                    CharChart.Add(keyboardPoints[i].Symbol.ToString());
                }
            }
            
        }
        #endregion

        #region Variables
        private List<KeyboardPoint> _keyboardPoints;
        private int _errorRate;
        #endregion

        private ChartValues<double> _Chart1 = new();
        public ChartValues<double> Chart1
        {
            get => _Chart1;
            set
            {
                _Chart1 = value;
                OnPropertyChanged();
            }
        }

        private ChartValues<double> _Chart2 = new();
        public ChartValues<double> Chart2
        {
            get => _Chart2;
            set
            {
                _Chart2 = value;
                OnPropertyChanged();
            }
        }

        private ChartValues<double> _Chart3 = new();
        public ChartValues<double> Chart3
        {
            get => _Chart3;
            set
            {
                _Chart3 = value;
                OnPropertyChanged();
            }
        }

        private List<string> _charChart = new();
        public List<string> CharChart
        {
            get => _charChart;
            set
            {
                _charChart = value;
                OnPropertyChanged();
            }
        }

        public SeriesCollection SeriesCollection { get; set; }

        public Func<double, string> YFormatter { get; set; }
    }
}
