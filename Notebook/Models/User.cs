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
        /// Есть ли у пользователя вход по клавиатурному подчерку
        /// </summary>
        public bool HasKeyboard { get; set; }

        /// <summary>
        /// Кодовая фраза для клавиатурного подчерка
        /// </summary>
        public string CodePhrase { get; set; }

        /// <summary>
        /// Погрешность клавиатурного подчерка
        /// </summary>
        public int ErrorRate { get; set; }

        /// <summary>
        /// Допустимое отклонение в пикселях
        /// </summary>
        public int DeltaPixels { get; set; }

        /// <summary>
        /// Количество попыток ввода графического ключа
        /// </summary>
        public int AmountOfAttempt { get; set; }

        /// <summary>
        /// Путь к картинке для графического ключа
        /// </summary>
        public string PathToImage { get; set; }

        /// <summary>
        /// Точки графического ключа данного пользователя 
        /// </summary>
        public ICollection<GraphKeyPoint> GraphKeyPoints { get; set; }

        /// <summary>
        /// Символы фразы данного пользователя
        /// </summary>
        public ICollection<KeyboardPoint> KeyboardPoints { get; set; }

        /// <summary>
        /// Запись данного пользователя 
        /// </summary>
        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}
