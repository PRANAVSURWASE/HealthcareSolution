using System.Collections.Generic;
using System.Threading.Tasks;
using PatientService.Models;

namespace PatientService.Repository
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByUsernameAsync(string username);
        Task<List<Patient>> GetAllAsync();
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
    }
}