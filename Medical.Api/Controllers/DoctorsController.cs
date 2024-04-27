using ArabityAuth;
using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IBaseRepository<Doctor> _doctorsRepository;
        private readonly IMapper _mapper;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _Environment;

        public DoctorsController(IBaseRepository<Doctor> doctorsRepository,
                                 IMapper mapper,
                                 Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _doctorsRepository = doctorsRepository;
            _mapper = mapper;
            _Environment = environment;
        }

        //[HttpPost("CreateNewDoctor")]
        //public async Task<IActionResult> Create([FromForm] DoctorDto dto)
        //{
        //    return Ok(await _doctorsRepository.CreateAsync(_mapper.Map<Doctor>(dto)));
        //}

        [HttpGet("GetDoctorById")]
        public async Task<IActionResult> GetByIdAsync(string phone)
        {
            var doctor = await _doctorsRepository.GetByIdAsync(phone);

            if (doctor == null)
                return NotFound("This Doctor is not Found!");

            var dto = _mapper.Map<DoctorDto>(doctor);

            return Ok(dto);
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _doctorsRepository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return Ok(dto);
        }
    }
}
