using Application.BlogCategory.Commands;
using Application.BlogCategory.Queries;
using Common.ActionStatus;
using Domain;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BlogCategoryController : BaseController
    {

        [HttpGet]
        public async Task<IList<Category>> GetAllCategory()
            => await Mediator.Send(new GetAllBlogCategory.Query());

        [HttpPost]
        public async Task<Category> UpSertCategory(Category category)
            => await Mediator.Send(new InsertOrUpdateBlogCategory.Command() { Category = category });

        [HttpDelete("{id}")]
        public async Task<AcctionSucces> DeleteCategory(string id)
            => await Mediator.Send(new DeleteBlogCategory.Command() { Id = id });
    }
}
