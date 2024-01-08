using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using WebApp_API.Interfaces;
using WebApp_API.Models;

namespace WebApp_API.Services
{
    public class UsersService : IUsers
    {
        private IConfiguration _config;
        public UsersService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<CreateUserResponse> CreateUser(CreateUser request)
        {
            var res = new CreateUserResponse();

            using var connection = new SqlConnection(_config.GetConnectionString("DefaultCon"));

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", request.UserId);
            parameters.Add("@UserName", request.UserName);
            parameters.Add("@UserType", request.UserType);
            parameters.Add("@Password", request.Password);

            var result = connection.ExecuteScalar<string>("proc_CreateUser",parameters, commandType: System.Data.CommandType.StoredProcedure);

            if(result == "00")
            {
                res.ResponseCode = "00";
                res.ResponseDescription = "Successful";
            }
            else
            {
                res.ResponseCode = "01";
                res.ResponseDescription = "Failed";
            }
            

            return res;

        }

        public async Task<List<User>> GetAllUser()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultCon"));  
            var result =  connection.Query<User>("proc_SelectAllUsers", commandType: System.Data.CommandType.StoredProcedure).ToList();   
            return result;

        }

        public async Task<User> GetUser(string user)
        {
  
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultCon"));
            var parameters = new DynamicParameters();
           
             parameters.Add("@UserId", user);
          
            var result =  connection.QueryFirstOrDefault<User>("proc_SelectUsers", parameters, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }
    }
}
