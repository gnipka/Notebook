using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notebook.Models;

namespace Notebook.Data.Abstract
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task<T?> GetByLoginAsync(string login);

        Task<User?> VerifyUserAsync(string username, string password);

        Task<bool> SaveAsync(T obj);

        Task DeleteAsync(int id);
    }
}
