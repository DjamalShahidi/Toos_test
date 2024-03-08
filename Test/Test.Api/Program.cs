using Test.Application;
using Test.Persistence;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;


builder.Services.ConfigureApplicationServices()
                .ConfigurePersistenceServices(configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
