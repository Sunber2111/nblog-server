using Common.Helper;
using Nest;
using System;

namespace Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IElasticClient ElasticClient { get; }
        Task CreateIndexIfNotExists(string indexName);
        Task<ISearchResponse<T>> SearchAsync(Func<SearchDescriptor<T>, ISearchRequest> selector = null);
        Task<T> Get(object key);
        Task<List<T>> GetAll();
        Task<List<T>> Query(QueryContainer predicate);
        Task<List<T>> Query(SearchRequest request);
        Task<List<T>> Query(QueryContainer predicate, FilterBase filter);
        Task<bool> AddOrUpdateBulk(IEnumerable<T> documents);
        Task<bool> AddOrUpdate(T document);
        Task<bool> Remove(object key);
    }
}

