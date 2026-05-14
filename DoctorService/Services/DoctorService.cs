using DoctorService.DTOs;
using DoctorService.Models;
using DoctorService.Repository;

namespace DoctorService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;

        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> AddDoctorAsync(DoctorDto dto)
        {
            var doctor = new Doctor
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Specialization = dto.Specialization
            };

            await _repo.AddAsync(doctor);
            return "Doctor Added Successfully";
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<string> UpdateDoctorAsync(int id, DoctorDto dto)
        {
            var doctor = await _repo.GetByIdAsync(id);

            if (doctor == null)
                return "Doctor Not Found";

            doctor.Name = dto.Name;
            doctor.Specialization = dto.Specialization;

            await _repo.UpdateAsync(doctor);

            return "Doctor Updated Successfully";
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}