using Microsoft.EntityFrameworkCore;
using VehiclesApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//contexto DB
builder.Services.AddDbContext<Parcial4dbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("conexionLocal"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql")));


// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")); // Esa es la direccion de Angular

    //admitir cualquier origen
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


var app = builder.Build();




// Habilitar CORS
app.UseCors("AllowAnyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Run();

//puerto especifico
app.Run();

