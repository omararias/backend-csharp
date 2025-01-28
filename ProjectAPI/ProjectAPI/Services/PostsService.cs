using System.Text.Json;
using ProjectAPI.DTOs;

namespace ProjectAPI.Services
{
    public class PostsService: IPostsService
    {


        private HttpClient _httpClient;

        public PostsService()
        {

            _httpClient = new HttpClient();

        }

        public async Task<IEnumerable<PostDto>> Get()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            var response = await _httpClient.GetAsync(url);
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
