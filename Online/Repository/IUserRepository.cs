using Online.Models;

namespace Online.Repository
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllUsers();
        Users GetUserById(string id);
        Users GetLastUserAdded();
        void UpdateUser(Users user);
        void Save();
    }
}
