using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Models
{
    public class GraphKeyPoint
    {
        /// <summary>
        /// Идентификатор точки графического ключа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Значение точки по X
        /// </summary>
        public int XValue { get; set; }
        
        /// <summary>
        /// Значение точки по Y
        /// </summary>
        public int YValue { get; set; }
        
        /// <summary>
        /// Номер точки в последовательности точек ключа
        /// </summary>
        public int NumberOfPoint { get; set; }

        /// <summary>
        /// Идентификатор пользователя для данной точки ключа
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
