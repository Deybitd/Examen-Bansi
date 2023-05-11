using WsApiexamen.Data;
using Microsoft.EntityFrameworkCore;
using WsApiexamen.Services.Abstract;
using WsApiexamen.Services.Concret;
using WsApiexamen.Repositories.Abstract;
using WsApiexamen.Repositories.Concret;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IExamenesService, ExamenesService>();
builder.Services.AddTransient<IExamenesRepository,ExamenesRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
