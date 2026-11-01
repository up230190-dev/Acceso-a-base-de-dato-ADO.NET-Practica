using ProductosApi.Data;
using ProductosApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Conexion>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
