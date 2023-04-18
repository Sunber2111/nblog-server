using System;
using Common.ActionStatus;
using Common.Errors;
using Domain;
using Infrastructure.Repository;
using MediatR;

namespace Application.BlogCategory.Queries
{
    public class GetAllBlogCategory
    {
        public class Query : IRequest<IList<Category>>
        {

        }

        public class Handler : IRequestHandler<Query, IList<Category>>
        {
            private readonly IGenericRepository<Category> _categoryRepository;

            public Handler(IGenericRepository<Category> repository)
            {
                _categoryRepository = repository;
            }

            public async Task<IList<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _categoryRepository.GetAll();
            }
        }
    }
}

