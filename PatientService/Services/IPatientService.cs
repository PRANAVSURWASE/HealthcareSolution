using PatientService.DTOs;
using PatientService.Models;

namespace PatientService.Services
{
    public interface IPatientService
    {
        Task<string> CreatePatientAsync(string username, PatientDto dto);
        Task<Patient?> GetPatientAsync(string username);
        Task<List<Patient>> GetAllAsync();
        Task<string> UpdatePatientAsync(string username, PatientDto dto);
    }
}