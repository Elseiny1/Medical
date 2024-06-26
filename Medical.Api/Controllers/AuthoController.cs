﻿using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoController : ControllerBase
    {

        private readonly IAuthoRepository _authoRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public AuthoController(IAuthoRepository authoRepository,
                               IMapper mapper,
                               IPatientRepository patientRepository,
                               IDoctorRepository doctorRepository)
        {
            _authoRepository = authoRepository;
            _mapper = mapper;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        [HttpPost("PatientRsegister")]
        public async Task<IActionResult> PatientRegisterAsync([FromBody] PatientDto patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var model = _mapper.Map<RegisterDTO>(patient);
            var register = await _authoRepository.RegisterAsync(model, "Patient");
            if (!register.IsAuthenticated)
                return BadRequest(register.Message);
 
            var result = await _patientRepository.AddPatientAsync(patient);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("DoctorRegister")]
        public async Task<IActionResult> DoctorRegisterAsync([FromBody] DoctorDto doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<RegisterDTO>(doctor);
            var register = await _authoRepository.RegisterAsync(model, "Doctor");
            if (!register.IsAuthenticated)
                return BadRequest(register.Message);
 
            var result = await _doctorRepository.AddDoctorAsync(doctor);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogInAsync([FromBody] LogInDTO user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authoRepository.GetTokenAsync(user);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }


    }
}
