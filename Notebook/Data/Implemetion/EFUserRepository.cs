using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
