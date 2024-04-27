using Medical.Core.Interfaces;
using Medical.Core.Models;
using Medical.Core.Repositories;
using Medical.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IBaseRepository<Clinic> _clinicsRepository;

        public ClinicsController(IBaseRepository<Clinic> clinicsRepository)
        {
            _clinicsRepository = clinicsRepository;
        }

        [HttpGet("GitClinics")]
        public async Task<IActionResult> GitClinics()
        {
            return Ok(await _clinicsRepository.GetAllAsync());
        }
    }
}
