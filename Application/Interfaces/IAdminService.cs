using Domain.request;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        public User AddEmployee(string username, string password);

        public List<User> GetAllUsers();

        public List<Request> GetPendingRequests();

        public Request GetRequestById(long RequestId);

        public Request ChangeRequestStatus(bool Accepted ,string? response, long RequestId);
    

    }
}
