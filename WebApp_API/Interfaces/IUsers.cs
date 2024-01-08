using WebApp_API.Models;

namespace WebApp_API.Interfaces
{
    public interface IUsers
    {
        public Task<CreateUserResponse> CreateUser(CreateUser request);

        public Task<User> GetUser(string user);

        public Task<List<User>>  GetAllUser();
    }
}
