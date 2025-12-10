using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.request;
using Domain.Users;

namespace Application.Interfaces
{
    public interface IUserService
    {
        //or EmployeeService
        public void AddRequest(DateTime srartdate, DateTime finishdate, string? Reason , long UserId);

        List<Request> GetAllUserRequest(long UserId);
        Request GetRequestById(long RequestId);
    }
}
