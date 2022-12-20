using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Models
{
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Имя пользователя, логин
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Пароль пользователя в зашифрованном виде
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        public DateTime DateRegister { get; set; } = DateTime.Now;

        /// <summary>
        /// Есть ли у пользователя графический ключ
        /// </summary>
        public bool HasGraphKey { get; set; }

        /// <summary>
        /// Путь к картинке для графического ключа
        /// </summary>
        public string PathToImage { get; set; }

        /// <summary>
        /// Точки графического ключа данного пользователя 
        /// </summary>
        public ICollection<GraphKeyPoint> GraphKeyPoints { get; set; }

        /// <summary>
        /// Запись данного пользователя 
        /// </summary>
        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}
