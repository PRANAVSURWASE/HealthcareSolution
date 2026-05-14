using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoctorService.DTOs;
using DoctorService.Services;

namespace DoctorService.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorsController(IDoctorService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorDto dto)
        {
            var result = await _service.AddDoctorAsync(dto);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DoctorDto dto)
        {
            var result = await _service.UpdateDoctorAsync(id, dto);
            return Ok(result);
        }

        [AllowAnonymous]   
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _service.GetByIdAsync(id);

            if (doctor == null)
                return NotFound("Doctor not found");

            return Ok(new
            {
                id = doctor.Id,
                name = doctor.Name
            });
        }
    }
}