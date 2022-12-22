using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Models
{
    public class KeyboardPoint
    {
        /// <summary>
        /// Идентификатор значения
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Введенный символ
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// Время между предыдущим и текущим
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Левая граница времени
        /// </summary>
        public long LeftLimit { get; set; }

        /// <summary>
        /// Правая граница времени
        /// </summary>
        public long RightLimit { get; set; }

        /// <summary>
        /// Номер символа в фразе
        /// </summary>
        public int NumberOfChar { get; set; }

        /// <summary>
        /// Идентификатор пользователя для данной точки ключа
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
