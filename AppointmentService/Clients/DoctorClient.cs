using AppointmentService.DTOs;

namespace AppointmentService.Clients
{
    public class DoctorClient
    {
        private readonly HttpClient _httpClient;

        public DoctorClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DoctorExistsAsync(int doctorId)
        {
            var response = await _httpClient.GetAsync($"/doctors/{doctorId}");
            return response.IsSuccessStatusCode;
        }

     
    }
}