using System;
using Common.ActionStatus;
using Common.Errors;
using Domain;
using Infrastructure.Repository;
using MediatR;

namespace Application.Blog.Commands
{
    public class DeleteBlog
    {
        public class Command : IRequest<AcctionSucces>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, AcctionSucces>
        {
            private readonly IGenericRepository<Domain.BlogPost> _blogPostRepository;

            public Handler(IGenericRepository<Domain.BlogPost> repository)
            {
                _blogPostRepository = repository;
            }

            public async Task<AcctionSucces> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _blogPostRepository.Remove(request.Id);
                return result ? new AcctionSucces() : throw new DeleteFailException();
            }
        }
    }
}

