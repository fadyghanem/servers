using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// enable controllers
builder.Services.AddControllers();

// enable swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// enable swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();