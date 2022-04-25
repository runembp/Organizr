using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Organizr.Core.Services;
using Organizr.Database;

var builder = WebApplication.CreateBuilder(args);
var sqliteConnectionString = new SqliteConnectionStringBuilder
{
    DataSource = "Organizr.db"
};

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrganizrDataContext>(options => options.UseSqlite(new SqliteConnection(sqliteConnectionString.ConnectionString), 
    x => x.MigrationsAssembly("Organizr.Database")));
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<PersonService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();