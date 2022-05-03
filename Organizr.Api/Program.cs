using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Repositories;
using System.Reflection;
using Organizr.Application.Handlers.RequestHandlers;
using Organizr.Application.HelperClasses;
using Organizr.Application.Requests;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Token Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Database and Identity
ApplicationDatabaseInitializerHelperClass.SetUpDatabaseAndIdentity(builder);

// Dependency injection
builder.Services.AddScoped<TokenHelperClass>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrganizrUserRepository, OrganizrUserRepository>();
builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
builder.Services.AddScoped<IRequestHandler<GetAllOrganizrUserRequest, List<OrganizrUser>>, GetAllOrganizrUserHandler>();
builder.Services.AddTransient<IRequestHandler<CreateOrganizrUserCommand, OrganizrUserResponse>, CreateOrganizrUserHandler>();
builder.Services.AddTransient<IRequestHandler<UserLoginRequest, UserLoginResponse>, UserLoginHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Organizr.API v1"));
}
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Seed Roles and Users to Database
ApplicationDatabaseInitializerHelperClass.SeedRolesToDb(app).Wait();
ApplicationDatabaseInitializerHelperClass.SeedMandatoryUsersToDatabase(app).Wait();

app.Run();