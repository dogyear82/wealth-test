using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Wealth.Infrastructure.Mongo;

public static class MongoConfig
{
    public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
    {
        var conn = configuration.GetSection("Mongo:ConnectionString").Value ?? "mongodb://mongo:27017";
        var dbName = configuration.GetSection("Mongo:Database").Value ?? "wealth";

        services.AddSingleton<IMongoClient>(_ => new MongoClient(conn));
        services.AddScoped(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(dbName));
        return services;
    }
}

