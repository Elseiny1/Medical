using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly IBaseRepository<Comment> _commentsRepository;
        private readonly IMapper _mapper;

        public CommentsController(IBaseRepository<Comment> commentsRepository,
                                  IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewComment")]
        public async Task<IActionResult> CreateNewComment([FromBody] CommentDto dto)
        {
            return Ok(await _commentsRepository.CreateAsync(_mapper.Map<Comment>(dto)));
        }

        [HttpGet("GetPostComments")]
        public async Task<IActionResult> GetPostComments([FromBody] string id)
        {
            var c = await _commentsRepository.GetAllAsync();
            List<Comment> comments = new List<Comment>();

            foreach (Comment comment in c)
            {
                if (comment.PostId == id)
                    comments.Add(comment);
            }

            var dto = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return Ok(dto);
        }
    }
}
