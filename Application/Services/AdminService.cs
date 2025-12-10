using Application.Interfaces;
using Domain.request;
using Domain.Users;
using Domain.Users.Enums;
using Infrastructure.EF_Core;
using Microsoft.EntityFrameworkCore;

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

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<Request> GetPendingRequests()
        {
            return _context.Requests.Where(p => p.Status == Domain.Requests.Enums.RequestStatus.Pending).Include(r => r.RequestedUser).ToList();
        }

        public Request GetRequestById(long RequestId)
        {
            return _context.Requests.Find(RequestId);
        }

        public Request ChangeRequestStatus(bool Accepted, string? response, long RequestId)
        {
            var request = _context.Requests.Find(RequestId);
            if (Accepted)
            {
                request.Status = Domain.Requests.Enums.RequestStatus.Accepted;
            }
            else
            {
                request.Status = Domain.Requests.Enums.RequestStatus.Rejected;
            }
            request.AdminResponse = response;
            _context.SaveChanges();
            return request;
        }
    }
}
