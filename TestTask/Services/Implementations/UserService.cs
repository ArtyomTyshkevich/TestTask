using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<User> GetUser()
        {
            User test = _db.Users
                .OrderByDescending(x => x.Orders.Count)
                .FirstOrDefault() ;
            return Task.FromResult(
                test);
        }

        public Task<List<User>> GetUsers()
        {
            return Task.FromResult(
                _db.Users
                .Where(x=> x.Status == Enums.UserStatus.Inactive)
                .ToList()
                );
        }
    }
}
