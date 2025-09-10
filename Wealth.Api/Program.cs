using HotChocolate.AspNetCore;
using Wealth.Api.GraphQL;
using Wealth.Infrastructure.Mongo;
using Wealth.Infrastructure.Repositories;
using Wealth.Core.Application.Ports;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongo(builder.Configuration);
builder.Services.AddScoped<IAssetRecordRepository, AssetRecordRepository>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGraphQL("/graphql");

app.Run();
