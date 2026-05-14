using DoctorService.DTOs;
using DoctorService.Models;

namespace DoctorService.Services
{
    public interface IDoctorService
    {
        Task<string> AddDoctorAsync(DoctorDto dto);
        Task<List<Doctor>> GetAllAsync();
        Task<string> UpdateDoctorAsync(int id, DoctorDto dto);
        Task<Doctor?> GetByIdAsync(int id);
    }
}