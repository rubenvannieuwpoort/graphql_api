var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    //.AddMutationType<Mutation>()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
