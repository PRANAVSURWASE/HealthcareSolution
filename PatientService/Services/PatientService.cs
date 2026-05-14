using PatientService.DTOs;
using PatientService.Models;
using PatientService.Repository;

namespace PatientService.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> CreatePatientAsync(string username, PatientDto dto)
        {
            var existing = await _repo.GetByUsernameAsync(username);

            if (existing != null)
            {
                existing.Name = dto.Name;
                existing.Age = dto.Age;

                await _repo.UpdateAsync(existing);

                return "Profile updated successfully";
            }

            var patient = new Patient
            {
                Username = username,
                Name = dto.Name,
                Age = dto.Age
            };

            await _repo.AddAsync(patient);

            return "Profile created successfully";
        }

        public async Task<Patient?> GetPatientAsync(string username)
        {
            return await _repo.GetByUsernameAsync(username);
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<string> UpdatePatientAsync(string username, PatientDto dto)
        {
            var patient = await _repo.GetByUsernameAsync(username);

            if (patient == null)
                return "Patient not found";

            patient.Name = dto.Name;
            patient.Age = dto.Age;

            await _repo.UpdateAsync(patient);

            return "Profile updated successfully";
        }
    }
}