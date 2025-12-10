using Application.Interfaces;
using Domain.Users;
using Domain.Users.Enums;
using Infrastructure.EF_Core;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;
        public AdminService(AppDbContext context)
        {
            _context = context;
        }
        public User AddEmployee(string username, string password)
        {
            var newUser = new User()
            {
                UserName = username,
                Password = password,
                Role = UserRole.Employee,

            };
            _context.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public List<User> AllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
