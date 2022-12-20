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
using Notebook.Models;

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для GraphKeyWindow.xaml
    /// </summary>
    public partial class GraphKeyWindow : Window
    {
        private List<XYPoint> points = new List<XYPoint>();
        private int i = 0;
        public GraphKeyWindow()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            points.Add( new XYPoint(i, e.GetPosition(image).X, e.GetPosition(image).Y));
            i++;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //да я нарушил mvvm
            ((dynamic)this.DataContext).ArrayOfPoints = new List<XYPoint>(points);
            //((dynamic)this.DataContext).ArrayOfPoints.AddRange(points);
            points.Clear();
            i = 0;
        }
    }
}
