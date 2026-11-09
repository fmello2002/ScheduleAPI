using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Application.UseCases;
using ScheduleAPI.Application.UseCases.Agendamentos;
using ScheduleAPI.Application.UseCases.Clientes;
using ScheduleAPI.Application.UseCases.Horarios;
using ScheduleAPI.Handlers;
using ScheduleAPI.Infrastructure.Persistence;
using ScheduleAPI.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScheduleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cliente
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<CadastrarCliente>();
builder.Services.AddScoped<BuscarCliente>();
builder.Services.AddScoped<BuscarClientes>();
// Atendente
builder.Services.AddScoped<IAtendenteRepository, AtendenteRepository>();
builder.Services.AddScoped<CadastrarAtendente>();
builder.Services.AddScoped<BuscarAtendente>();
builder.Services.AddScoped<BuscarAtendentes>();
// Horario
builder.Services.AddScoped<IHorarioRepository, HorarioRepository>();
builder.Services.AddScoped<CadastrarHorario>();
builder.Services.AddScoped<BuscarHorarios>();
builder.Services.AddScoped<BuscarHorario>();
builder.Services.AddScoped<BuscarHorariosPorDia>();
// Agendamento
builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
builder.Services.AddScoped<NovoAgendamento>();
builder.Services.AddScoped<BuscarAgendamentosPorClienteId>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddExceptionHandler<DomainExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();