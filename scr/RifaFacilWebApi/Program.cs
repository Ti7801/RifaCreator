using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Services;
using BibliotecaData.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(
    (DbContextOptionsBuilder optionsBuilder) =>
    {
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    },
    ServiceLifetime.Scoped
);

builder.Services.AddScoped<IRifaRepository, RifaRepository>();
builder.Services.AddScoped<CadastrarRifaService>();
builder.Services.AddScoped<ConsultarRifaService>();
builder.Services.AddScoped<AtualizarRifaService>();
builder.Services.AddScoped<ExcluirRifaService>();

builder.Services.AddScoped<IBilheteRepository, BilheteRepository>();
builder.Services.AddScoped<ComprarBilheteService>();
builder.Services.AddScoped<ConsultarBilheteService>();
builder.Services.AddScoped<AtualizarBilheteService>();
builder.Services.AddScoped<ExcluirBilheteService>();
builder.Services.AddScoped<SortearBilheteService>();

builder.Services.AddScoped<IRifadorRepository, RifadorRepository>();
builder.Services.AddScoped<CadastrarRifadorService>();
builder.Services.AddScoped<ConsultarRifadorService>();
builder.Services.AddScoped<AtualizarRifadorService>();
builder.Services.AddScoped<ExcluirRifadorService>();

builder.Services.AddScoped<IAfiliadoRepository, AfiliadoRepository>();
builder.Services.AddScoped<CadastrarAfiliadoService>();
builder.Services.AddScoped<ConsultarAfiliadoService>();
builder.Services.AddScoped<ConsultarAfiliadoPorIdService>();
builder.Services.AddScoped<AtualizarAfiliadoService>();
builder.Services.AddScoped<ExcluirAfiliadoService>();


builder.Services.AddControllers();
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
