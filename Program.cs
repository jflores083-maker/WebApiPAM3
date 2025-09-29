using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ContactoService>();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.MapGet("/minimal/contactos",(ContactoService servicio) =>{
    return Results.Ok (servicio.ObtenerTodo());
}).WithName("ObtenerTodos").WithTags("Minimal_Contacto").WithOpenApi();
//app.UseHttpRedirection();
app.MapControllers();
app.Run();

