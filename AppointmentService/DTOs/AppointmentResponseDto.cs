namespace AppointmentService.DTOs
{
    public class AppointmentResponseDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }
}
