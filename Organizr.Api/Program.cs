using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Data;
using Organizr.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<OrganizrDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee.API",
        Version = "v1"
    });
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(CreateOrganizrUserHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IOrganizrUserRepository, OrganizrUserRepository>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee.API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();

app.Run();