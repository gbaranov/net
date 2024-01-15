using net.Data;
using Microsoft.EntityFrameworkCore;
using net.Repositories.Interface;
using net.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Test change, another change

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURESQL"));

});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin()
                               .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthChecks("/health");
app.UseAuthorization();

app.MapControllers();
app.Run();

