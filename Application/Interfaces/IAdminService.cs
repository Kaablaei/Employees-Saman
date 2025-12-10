using Domain.Users;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        public User AddEmployee(string username, string password);

        public List<User> AllUsers();
    }
}
