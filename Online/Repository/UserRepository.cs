using Online.Data;
using Online.Models;

namespace Online.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Users GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public Users GetLastUserAdded()
        {
            return _context.Users.OrderByDescending(u => u.RegistrationDate).FirstOrDefault();
        }

        public void UpdateUser(Users user)
        {
            _context.Users.Update(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
