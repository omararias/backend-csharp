namespace ProjectAPI.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int UserId { get; set; }

        public string? Body { get; set; }
    }
}
