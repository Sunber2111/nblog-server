using Nest;

namespace API.ConfigServices
{
    public static class ElasticConfiguration
    {
        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ELKConfiguration:Url"];
            var username = configuration["ELKConfiguration:UserName"];
            var password = configuration["ELKConfiguration:Password"];

            var settings = new ConnectionSettings(new Uri(url)).BasicAuthentication(username,password).PrettyJson();

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }

    }
}
