using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options => options.UseSqlite("Data Source=database.db"));

builder.Services
    .AddGraphQLServer()
    //.AddMutationType<Mutation>()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
