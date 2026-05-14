using AppointmentService.DTOs;
using AppointmentService.Models;

namespace AppointmentService.Services
{
    public interface IAppointmentService
    {
        Task<string> BookAsync(AppointmentDto dto);
        Task<string> BookAsync(AppointmentDto dto, int patientId);
        Task<List<Appointment>> GetForPatientAsync(int patientId);
       // Task<List<Appointment>> GetForDoctorAsync(int doctorId);
        Task<List<Appointment>> GetAllAsync();
        Task<string> CancelByPatientAsync(int id, int patientId);
        Task<string> CancelByDoctorAsync(int id, int doctorId);
        Task<string> CompleteAsync(int id, int doctorId);
        Task<string> CancelByAdminAsync(int id);

        Task<List<AppointmentResponseDto>> GetForDoctorAsync(int doctorId);
       // Task<List<AppointmentResponseDto>> GetAllAsync();
    }
}