using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientService.DTOs;
using PatientService.Services;
using System.Security.Claims;

namespace PatientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        private string GetUsername()
        {
            return User.FindFirst(ClaimTypes.Name)?.Value
                   ?? throw new InvalidOperationException("User name claim missing.");
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        public async Task<IActionResult> Create(PatientDto dto)
        {
            var username = GetUsername();
            var result = await _service.CreatePatientAsync(username, dto);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var username = GetUsername();
            var result = await _service.GetPatientAsync(username);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
            
        [Authorize(Roles = "Patient")]
        [HttpPut]
        public async Task<IActionResult> Update(PatientDto dto)
        {
            var username = GetUsername();
            var result = await _service.UpdatePatientAsync(username, dto);
            return Ok(result);
        }
    }
}