
using Application.Blog.Commands;
using Application.Blog.Queries;
using Common.ActionStatus;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BlogPostController : BaseController
    {
        [HttpPost("filter")]
        public async Task<IList<BlogPost>> GetBlogPostByFilter(GetBlogByFilter.Query query)
            => await Mediator.Send(query);

        [HttpPost]
        public async Task<BlogPost> UpSertBlogPost(InsertOrUpdateBlog.Command command)
            => await Mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task<AcctionSucces> DeleteBlogPost(string id)
            => await Mediator.Send(new DeleteBlog.Command { Id = id });
    }
}

