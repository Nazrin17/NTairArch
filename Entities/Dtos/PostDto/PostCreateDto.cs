using Microsoft.AspNetCore.Http;

namespace Entites.Dtos.PostDto
{
    public class PostCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile formFile { get; set; }
    }
}
