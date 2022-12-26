using LiveCharts;
using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_Classes;

namespace Notebook.ViewModels
{
    class Table
    {
        public char Symbol { get; set; }
        public double Time { get; set; }
        public double LowerLimit { get; set; }
        public double UpperLimit { get; set; }
        public string Result { get; set; }
        

    }

    internal class ReportViewModel : ViewModelBase
    {
        #region Constructors
        public ReportViewModel(List<Result> results, string resultString, bool visible)
        {
            YFormatter = value => value.ToString("N2");

            if (visible)
                Visible = Visibility.Visible;
            else
                Visible = Visibility.Collapsed;

            Tables = new List<Table>();

            for(int i = 0; i < results.Count; i++)
            {
                Tables.Add(new Table
                {
                    Symbol = results[i].Point.Symbol,
                    Time = Math.Round(results[i].Time / 1000, 2),
                    LowerLimit = Math.Round((double)results[i].Point.LeftLimit / 1000, 2),
                    UpperLimit = Math.Round((double)results[i].Point.RightLimit / 1000, 2),
                    Result = results[i].ResultStirng
                });

                Chart1.Add(Tables[i].UpperLimit);
                Chart2.Add(Tables[i].Time);
                Chart3.Add(Tables[i].LowerLimit);
                CharChart.Add(results[i].Point.Symbol.ToString());
            }

            ResultString = resultString;
            
        }
        #endregion

        #region Variables

        private List<Table> _tables;
        private string _resultString;
        private Visibility _visible;

        #endregion
        #region Properties

        public List<Table> Tables
        {
            get => _tables;
            set
            {
                _tables = value;
                OnPropertyChanged();
            }
        }

        public string ResultString
        {
            get => _resultString;
            set
            {
                _resultString = value;
                OnPropertyChanged();
            }
        }

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

        public Visibility Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                OnPropertyChanged();
            }
        }

        public SeriesCollection SeriesCollection { get; set; }

        public Func<double, string> YFormatter { get; set; }

        #endregion
    }
}
