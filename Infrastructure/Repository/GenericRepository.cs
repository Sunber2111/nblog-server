using System;
using System.Xml.Linq;
using Common.Helper;
using Elasticsearch.Net;
using Nest;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IElasticClient _elasticClient;
        private readonly string _indexName;
        public IElasticClient ElasticClient => _elasticClient;

        public GenericRepository(IElasticClient elasticClient)
        {
            _indexName = typeof(T).Name.ToString().ToLower();
            _elasticClient = elasticClient;
        }

        public async Task<ISearchResponse<T>> SearchAsync(Func<SearchDescriptor<T>, ISearchRequest> selector = null)
        {
            return await _elasticClient.SearchAsync<T>(selector => selector.Index(_indexName));
        }

        public async Task CreateIndexIfNotExists(string indexName)
        {
            if (!_elasticClient.Indices.Exists(indexName).Exists)
            {
                await _elasticClient.Indices.CreateAsync(indexName, c => c.Map<dynamic>(m => m.AutoMap()));
            }
        }

        public async Task<T> Get(object key)
        {
            var response = await _elasticClient.GetAsync<T>(key.ToString(), g => g.Index(_indexName));
            return response.Source;
        }

        public async Task<List<T>> GetAll()
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(s => s.Index(_indexName).Query(q => q.MatchAll()));
            return searchResponse.IsValid ? searchResponse.Documents.ToList() : new List<T>();
        }

        public async Task<List<T>> Query(QueryContainer predicate)
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(s => s.Index(_indexName).Query(q => predicate));
            return searchResponse.IsValid ? searchResponse.Documents.ToList() : new List<T>();
        }


        public async Task<List<T>> Query(QueryContainer predicate, FilterBase filter)
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(s => s.Index(_indexName).From(filter.From).Take(filter.Take).Query(q => predicate));
            return searchResponse.IsValid ? searchResponse.Documents.ToList() : new List<T>();
        }

        public async Task<List<T>> Query(SearchRequest request)
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(request);
            return searchResponse.IsValid ? searchResponse.Documents.ToList() : new List<T>();
        }

        public async Task<bool> AddOrUpdateBulk(IEnumerable<T> documents)
        {
            var indexResponse = await _elasticClient.BulkAsync(b => b
                  .Index(_indexName)
                  .UpdateMany(documents, (ud, d) => ud.Doc(d).DocAsUpsert(true))
              );
            return indexResponse.IsValid;
        }

        public async Task<bool> AddOrUpdate(T document)
        {
            var indexResponse = await _elasticClient.IndexAsync(document, idx => idx.Index(_indexName).OpType(OpType.Index));
            return indexResponse.IsValid;
        }

        public async Task<bool> Remove(object key)
        {
            var response = await _elasticClient.DeleteAsync<T>(key.ToString(), d => d.Index(_indexName));
            return response.IsValid;
        }

    }
}

