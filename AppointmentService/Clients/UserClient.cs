using AppointmentService.DTOs;
using static System.Net.WebRequestMethods;

namespace AppointmentService.Clients
{
    public class UserClient
    {
        private readonly HttpClient _http;

        public UserClient(HttpClient http)
        {
            _http = http;
        }
        public async Task<string?> GetUsernameAsync(int userId)
        {
            var response = await _http.GetAsync($"/api/users/{userId}");

            if (!response.IsSuccessStatusCode)
                return null;

            var user = await response.Content.ReadFromJsonAsync<UserDto>();
            return user?.Username;
        }
    }
}
