using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Notebook.Data.Abstract;
using Notebook.Domain;
using Notebook.Models;

namespace Notebook.Data.Implemetion
{
    public class EFUserRepository : IRepository<User>
    {
        private readonly ApplicationContext _context;

        public EFUserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _context.Users
                .Include(x => x.GraphKeyPoints)
                .Include(x => x.KeyboardPoints)
                .Include(x => x.Note)
                .ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.GraphKeyPoints).Include(x => x.KeyboardPoints).Include(x => x.Note).FirstAsync(m => m.Id == id);
        }

        public async Task<User?> GetByLoginAsync(string login)
        {
            return await _context.Users.Include(x => x.GraphKeyPoints).Include(x => x.KeyboardPoints).Include(x => x.Note).FirstOrDefaultAsync(m => m.Username == login);

        }

        public async Task<User?> VerifyUserAsync(string username, string password)
        {
            var user = await GetByLoginAsync(username);
            if (user != null)
            {
                var passwordEncode = Cipher(password, GenerateKey(user.DateRegister.Ticks));
                var value = _context.Users
                    .Include(x => x.GraphKeyPoints)
                    .Include(x => x.KeyboardPoints)
                    .Include(x => x.Note)
                    .ToList()
                    .FirstOrDefault(x => x.Username == username && Regex.Unescape(x.Password) == passwordEncode);
                return value;
            }
            return null;
        }

        public async Task<bool> SaveAsync(User user)
        {
            try
            {
                if (user.Id == 0)
                    await _context.Users.AddAsync(user);
                else
                {
                    var dbEntry = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.Username = user.Username;
                        dbEntry.Password = user.Password;
                        dbEntry.DateRegister = user.DateRegister;
                        dbEntry.HasGraphKey = user.HasGraphKey;
                        dbEntry.HasKeyboard = user.HasKeyboard;
                        dbEntry.CodePhrase = user.CodePhrase;
                        dbEntry.ErrorRate = user.ErrorRate;
                        dbEntry.DeltaPixels = user.DeltaPixels;
                        dbEntry.AmountOfAttempt = user.AmountOfAttempt;
                        dbEntry.AmountOfSymbol = user.AmountOfSymbol;
                        dbEntry.PathToImage = user.PathToImage;
                        dbEntry.GraphKeyPoints = user.GraphKeyPoints;
                        dbEntry.KeyboardPoints = user.KeyboardPoints;            
                        dbEntry.Note = user.Note;
                    }
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Users.FindAsync(id);
            if (value != null)
                _context.Users.Remove(value);
            await _context.SaveChangesAsync();
        }

        //генератор повторений пароля
        private string GetRepeatKey(string s, int n)
        {
            var r = s;
            while (r.Length < n)
            {
                r += r;
            }

            return r.Substring(0, n);
        }

        //метод шифрования/дешифровки
        private string Cipher(string text, string secretKey)
        {
            var currentKey = GetRepeatKey(secretKey, text.Length);
            var res = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                res += ((char)(text[i] ^ currentKey[i])).ToString();
            }

            return res;
        }

        //генерация ключа для пользователя в зависимости от времени регистрации
        private string GenerateKey(long ticks)
        {
            var alphabet = new List<string>
            {
                "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й",
                "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х",
                "ц", "ч", "ш", "щ", "э", "ю", "я"
            };

            var key = new StringBuilder();
            key.Append(alphabet[(int)(ticks % 31)]);
            key.Append(alphabet[(int)(ticks % 32)]);
            key.Append(alphabet[(int)(ticks % 33)]);

            return key.ToString();
        }
    }
}
