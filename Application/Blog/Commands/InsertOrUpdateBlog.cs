using System;
using Common.Errors;
using Domain;
using Infrastructure.Repository;
using MediatR;

namespace Application.Blog.Commands
{
    public class InsertOrUpdateBlog
    {
        public class Command : IRequest<BlogPost>
        {
            public BlogPost BlogPost { get; set; }
        }

        public class Handler : IRequestHandler<Command, BlogPost>
        {
            private readonly IGenericRepository<BlogPost> _blogPostRepository;

            public Handler(IGenericRepository<BlogPost> repository)
            {
                _blogPostRepository = repository;
            }

            public async Task<BlogPost> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _blogPostRepository.AddOrUpdate(request.BlogPost);
                return result ? request.BlogPost : throw new UpSertFailException();
            }
        }
    }
}

