using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                .Include(x => x.Note)
                .ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.GraphKeyPoints).Include(x => x.Note).FirstAsync(m => m.Id == id);
        }

        public async Task<User?> VerifyUserAsync(string username, string password)
        {
            var passwordEncode = Cipher(password, "n");
            var value = _context.Users
                .Include(x => x.GraphKeyPoints)
                .Include(x => x.Note)
                .ToList()
                .FirstOrDefault(x => x.Username == username && Regex.Unescape(x.Password) == passwordEncode);
            return value;
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
                        dbEntry.PathToImage = user.PathToImage;
                        dbEntry.HasGraphKey = user.HasGraphKey;
                        dbEntry.GraphKeyPoints = user.GraphKeyPoints;
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

            Debug.WriteLine(res);
            return res;
        }

    }
}
