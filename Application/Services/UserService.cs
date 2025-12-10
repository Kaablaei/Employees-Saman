using Application.Interfaces;
using Domain.request;
using Domain.Requests.Enums;
using Infrastructure.EF_Core;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public void AddRequest(DateTime srartdate, DateTime finishdate, string? Reason, long UserId)
        {
            _context.Requests.Add(new Request()
            {
                RequestedUserId = UserId,
                StardDate = srartdate,
                FinishDateDate = finishdate,
                CratedDate = DateTime.Now,
                Reason = Reason,
                Status = RequestStatus.Pending,
            });
            _context.SaveChanges();
        }

        public List<Request> GetAllUserRequest(long UserId)
        {
            return _context.Requests.Where(p=>p.RequestedUserId == UserId) .ToList();
        }

        public Request GetRequestById(long RequestId)
        {
            return _context.Requests.Find(RequestId);
        }
    }
}
