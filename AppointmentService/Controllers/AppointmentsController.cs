using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppointmentService.DTOs;
using AppointmentService.Services;
using System.Security.Claims;

namespace AppointmentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        public async Task<IActionResult> Book(AppointmentDto dto)
        {
            var patientId = GetUserId();
            var result = await _service.BookAsync(dto, patientId);
            return Ok(result);
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("my")]
        public async Task<IActionResult> MyAppointments()
        {
            var patientId = GetUserId();
            return Ok(await _service.GetForPatientAsync(patientId));
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("doctor")]
        public async Task<IActionResult> DoctorAppointments()
        {
            var doctorId = GetUserId();
            return Ok(await _service.GetForDoctorAsync(doctorId));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [Authorize(Roles = "Patient")]
        [HttpPut("cancel/patient/{id}")]
        public async Task<IActionResult> CancelByPatient(int id)
        {
            var patientId = GetUserId();
            var result = await _service.CancelByPatientAsync(id, patientId);
            return Ok(result);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPut("cancel/doctor/{id}")]
        public async Task<IActionResult> CancelByDoctor(int id)
        {
            var doctorId = GetUserId();
            var result = await _service.CancelByDoctorAsync(id, doctorId);
            return Ok(result);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> Complete(int id)
        {
            var doctorId = GetUserId();
            var result = await _service.CompleteAsync(id, doctorId);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("cancel/admin/{id}")]
        public async Task<IActionResult> CancelByAdmin(int id)
        {
            var result = await _service.CancelByAdminAsync(id);
            return Ok(result);
        }
    }
}