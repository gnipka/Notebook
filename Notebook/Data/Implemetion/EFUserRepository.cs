using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                .Include(x => x.Notes)
                .ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.GraphKeyPoints).Include(x => x.Notes).FirstAsync(m => m.Id == id);
        }

        public async Task<User?> VerifyUserAsync(string username, string password)
        {
            var passwordEncode = Cipher(password, 'n');
            var value = await _context.Users
                .Include(x => x.GraphKeyPoints)
                .Include(x => x.Notes)
                .FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordEncode);
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
                        dbEntry.Notes = user.Notes;
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

        private string Cipher(string text, char secretKey)
        {
            var res = new StringBuilder();
            foreach (var t in text)
            {
                res.Append(t ^ secretKey);
            }

            return res.ToString();
        }

    }
}
