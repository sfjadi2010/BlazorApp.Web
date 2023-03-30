using Newtonsoft.Json;

namespace BlazorApp.Web.Data
{
    public class UsersService
    {
        public async Task<User> GetUsersAsync()
        {
            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://reqres.in/api/")
            })
            {
                HttpResponseMessage response = await httpClient.GetAsync("users");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<User>();

                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return new User();
        }
    }
}
