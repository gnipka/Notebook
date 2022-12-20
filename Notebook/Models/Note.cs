using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Notebook.Models
{
    public class Note
    {
        /// <summary>
        /// Идентификатор записи в блокноте
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст записи в блокноте
        /// </summary>
        public string NoteText { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.Now;

        /// <summary>
        /// Дата внесения изменений в запись
        /// </summary>
        public DateTime? DateUpdated { get; set; }

        /// <summary>
        /// Идентификатор пользователя-автора записи
        /// </summary>
        public User User { get; set; }
    }
}
