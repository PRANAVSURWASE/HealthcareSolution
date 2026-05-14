using AppointmentService.Models;

namespace AppointmentService.Repository
{
    public interface IAppointmentRepository
    {
        Task AddAsync(Appointment appointment);
        Task<Appointment?> GetByIdAsync(int id);
        Task<List<Appointment>> GetAllAsync();
        Task<List<Appointment>> GetByPatientAsync(int patientId);
        Task<List<Appointment>> GetByDoctorAsync(int doctorId);
        Task UpdateAsync(Appointment appointment);
    }
}