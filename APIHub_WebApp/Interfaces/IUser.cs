using APIHub_WebApp.Models;

namespace APIHub_WebApp.Interfaces
{
    public interface IUser
    {
        public Task<CreateUserRes> CreateUser(CreateUser request);
        public Task<List<UserModel>> AllUsers();
    }
}
