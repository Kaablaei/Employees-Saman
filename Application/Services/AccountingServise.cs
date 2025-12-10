using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Users;
using Infrastructure.EF_Core;

namespace Application.Services
{
    public class AccountingServise : IAccountingServise
    {
        private readonly AppDbContext _context;
        public AccountingServise(AppDbContext context)
        {
            _context = context;
        }
        User IAccountingServise.GetUserInfo(string username, string password)
        {
            return _context.Users.SingleOrDefault(p => p.UserName == username && p.Password == password);
        }
    }
}
