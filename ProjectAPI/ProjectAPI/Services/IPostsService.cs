using ProjectAPI.DTOs;

namespace ProjectAPI.Services
{
    public interface IPostsService
    {

        public Task<IEnumerable<PostDto>> Get();
    }
}
