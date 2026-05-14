namespace DoctorService.DTOs
{
    public class DoctorDto
    {
        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;
    }
}