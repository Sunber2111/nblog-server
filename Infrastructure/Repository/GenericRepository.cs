using System;
using System.Xml.Linq;
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

        public async Task<bool> Add(T data)
        {   
            object id = data.GetType().GetProperty("Id").GetValue(data, null);

            if (id == null)
            {
                throw new Exception("Id Was Null");
            }

            var result = await _elasticClient.IndexAsync(data, i => i.Index(_indexName).Id(id.ToString()));

            return result.IsValid;
        }

    }
}

