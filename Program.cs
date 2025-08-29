using Microsoft.EntityFrameworkCore;
using newapi.domain.services;
using newapi.infra.data;
using newapi.infra.interfaces;
using newapi.routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UserRoutes();

app.UseHttpsRedirection();

app.Run();
