using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Models
{
    public class XYPoint
    {
        public XYPoint(double x, double y)
        {
            X = x;
            Y = y;
        } 
        
        public XYPoint(int n, double x, double y)
        {
            NumberOfPoint = n;
            X = x;
            Y = y;
        }

        public int NumberOfPoint { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
