using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.request;
using Domain.Users;

namespace Application.Interfaces
{
    public interface IAccountingServise
    {
        User GetUserInfo(string username, string password);

     
    }
}
