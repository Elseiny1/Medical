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
    public class PostsController : ControllerBase
    {

        private readonly IBaseRepository<Post> _postsRepository;
        private readonly IMapper _mapper;

        public PostsController(IBaseRepository<Post> postsRepository,
                               IMapper mapper)
        {
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewPost")]
        public async Task<IActionResult> CreateNewPost([FromBody] PostDto dto)
        {
            return Ok(await _postsRepository.CreateAsync(_mapper.Map<Post>(dto)));
        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postsRepository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<PostDto>>(posts);

            return Ok(dto);
        }

        [HttpGet("GetAllDoctorPosts")]
        public async Task<IActionResult> GetAllDoctorPosts(string phone)
        {
            var p = await _postsRepository.GetAllAsync();
            List<Post> posts = new List<Post>();

            foreach(Post post in p)
            {
                if (post.DoctorPhone == phone)
                    posts.Add(post);     
            }

            var dto = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(dto);
        }
  
    }
}
