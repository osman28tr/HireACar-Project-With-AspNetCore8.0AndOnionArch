using HireACar.Application;
using HireACar.Insfrastructure;
using HireACar.Persistance;
using HireACar.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HireACarContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
});
builder.Services.AddApplicationRegistration();
builder.Services.AddPersistanceRegistration();
builder.Services.AddScoped<DbContext, HireACarContext>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});
builder.Services.AddInfrastructureRegistration();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
