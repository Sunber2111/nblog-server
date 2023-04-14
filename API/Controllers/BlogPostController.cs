using Domain;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IGenericRepository<BlogPost> _blogPostRepository;

        public BlogPostController(IGenericRepository<BlogPost> blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogPost blogPost)
        {
            await _blogPostRepository.Add(blogPost);
            return Ok();
        }
    }
}
