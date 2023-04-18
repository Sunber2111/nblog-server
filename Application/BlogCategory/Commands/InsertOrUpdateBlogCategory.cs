using System;
using Domain;
using MediatR;
using Infrastructure.Repository;
using Common.Errors;

namespace Application.BlogCategory.Commands
{
    public class InsertOrUpdateBlogCategory
    {
        public class Command : IRequest<Category>
        {
            public Category Category { get; set; }
        }

        public class Handler : IRequestHandler<Command, Category>
        {
            private readonly IGenericRepository<Category> _categoryRepository;

            public Handler(IGenericRepository<Category> repository)
            {
                _categoryRepository = repository;
            }

            public async Task<Category> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _categoryRepository.AddOrUpdate(request.Category);
                return result ? request.Category : throw new UpSertFailException();
            }
        }
    }
}

