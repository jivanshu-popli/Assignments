using flightapi.Models;
using flightapi.Service;
using flightapi.Repository;
using Microsoft.EntityFrameworkCore;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
 
builder.Services.AddControllers();
builder.Services.AddScoped<IAdmin3<CustomersJivanshu>,Admin3Repo>();
builder.Services.AddScoped<IAdmin3Serv<CustomersJivanshu>,Admin3Serv>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 builder.Services.AddDbContext<Ace52024Context>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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