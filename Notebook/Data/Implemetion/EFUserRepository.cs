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
            return _context.Users.ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstAsync(m => m.Id == id);
        }

        public async Task<bool> VerifyUserAsync(string username, string password)
        {
            //TODO: пока без шифрования
            var value = await _context.Users.FirstOrDefaultAsync(x => (x.Username == username && x.Password == password));
            return value != null;
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
    }
}
