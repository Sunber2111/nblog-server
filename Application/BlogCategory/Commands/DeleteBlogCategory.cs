using System;
using Common.ActionStatus;
using Common.Errors;
using Domain;
using Infrastructure.Repository;
using MediatR;

namespace Application.BlogCategory.Commands
{
    public class DeleteBlogCategory
    {
        public class Command : IRequest<AcctionSucces>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, AcctionSucces>
        {
            private readonly IGenericRepository<Category> _categoryRepository;

            public Handler(IGenericRepository<Category> repository)
            {
                _categoryRepository = repository;
            }

            public async Task<AcctionSucces> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _categoryRepository.Remove(request.Id);
                return result ? new AcctionSucces() : throw new DeleteFailException();
            }
        }
    }
}

