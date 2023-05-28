using Verbos.Api.Controllers;
using Verbos.Application.serviços;
using Verbos.Domain.Contratos;
using Verbos.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ILocadora, LocadoraServices>();
builder.Services.AddScoped<IBancoDados, BancoDados>();
//builder.Services.AddSingleton<ILocadora, LocadoraServices>();// necessario caso deseja guarda em uma lista ao inves do banco de dados, pois no padrão cria uma instacia para cada solicitação addsingleton permite não criar uma instacia para cada solicitação
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
