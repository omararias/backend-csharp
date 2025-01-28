using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.DTOs;
using ProjectAPI.Services;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostsService _titlesService;

        public PostsController(IPostsService titlesService)
        {
            _titlesService = titlesService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get ()=>
            await _titlesService.Get();
    }
}
