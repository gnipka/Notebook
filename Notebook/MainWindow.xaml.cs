using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<XYPoint> points = new List<XYPoint>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            points.Add(new XYPoint(e.GetPosition(image).X, e.GetPosition(image).Y));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ((dynamic)this.DataContext).ArrayOfPoints = points;
        }
    }
}
