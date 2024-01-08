using APIHub_WebApp.Interfaces;
using APIHub_WebApp.Models;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace APIHub_WebApp
{
    public class CreateUserService : IUser
    {
        public Task<List<UserModel>> AllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserRes> CreateUser(CreateUser request)
        {
            var resp = new CreateUserRes();
            using (var client = new HttpClient())
            {
  
                client.BaseAddress = new Uri("http://localhost:5271");

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

       

         
            try
            {

                var response = await client.PostAsync("/api/CreateUser", content);
                response.EnsureSuccessStatusCode();

                // Read and display the response
                string responseBody = await response.Content.ReadAsStringAsync();
                if(responseBody != null)
                    {
                        resp = JsonConvert.DeserializeObject<CreateUserRes>(responseBody);                      
                    }
                    else
                    {
                        resp.ResponseCode = "01";
                        resp.ResponseDescription = "Failed";
                    }
    
            }
            catch (HttpRequestException e)
            {
                
            }
        }

            return resp;
    }
    }
}
