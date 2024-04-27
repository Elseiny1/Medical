using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Medical.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository booksRepository,
                               IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateBookAsync")]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookDto dto)
        {
            return Ok(await _booksRepository.CreateAsync(_mapper.Map<Book>(dto)));
        }

        [HttpGet("GetAllDoctorBooks")]
        public async Task<IActionResult> GetAllDoctorBooks(string phone)
        {
            return Ok(await _booksRepository.GetAllDoctorBooksAsync(phone));
        }

        [HttpGet("GetAllDoctorBooksInDay")]
        public async Task<IActionResult> GetAllDoctorBooksInDay(string phone , string date)
        {
            return Ok(await _booksRepository.GetAllDoctorBooksInDayAsync(phone,date));
        }
    }
}
