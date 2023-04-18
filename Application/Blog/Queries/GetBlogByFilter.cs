using System;
using Common.Helper;
using Domain;
using Infrastructure.Repository;
using MediatR;
using static System.Net.WebRequestMethods;

namespace Application.Blog.Queries
{
    public class GetBlogByFilter
    {
        public class Query : IRequest<IList<BlogPost>>
        {
            public FilterBase? Filter { get; set; }

            public Guid? CategoryId { get; set; }
        }

        public class Handler : IRequestHandler<Query, IList<BlogPost>>
        {
            private readonly IGenericRepository<BlogPost> _blogPostRepository;

            public Handler(IGenericRepository<BlogPost> repository)
            {
                _blogPostRepository = repository;
            }

            public async Task<IList<BlogPost>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = new Nest.QueryContainer();
                var filter = request.Filter ?? new FilterBase();

                if (request.CategoryId != null)
                {
                    query = new Nest.MatchPhraseQuery()
                    {
                        Field = "categoryId",
                        Query = request.CategoryId.ToString()
                    };
                }

                var result = await _blogPostRepository.Query(query, filter);
                return result;
            }
        }
    }
}

