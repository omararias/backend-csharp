using System.Text.Json;
using ProjectAPI.DTOs;

namespace ProjectAPI.Services
{
    public class PostsService: IPostsService
    {


        private HttpClient _httpClient;

        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PostDto>> Get()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await response.Content.ReadAsStringAsync();


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var post= JsonSerializer.Deserialize<IEnumerable<PostDto>>(body,options);

            return post;

        }

    }
}
